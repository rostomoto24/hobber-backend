using System.Net;
using System.Net.Http.Json;
using Hobber.Application.Common;
using Hobber.Application.Contracts;
using Hobber.Persistance.Seeding;

namespace Hobber.Tests;

public sealed class FilterTests(HobberApiFactory factory) : IClassFixture<HobberApiFactory>
{
    private async Task<List<string>> TitlesAsync(string query)
    {
        var client = factory.CreateClient();
        var page = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>($"/api/courses?pageSize=50&{query}"))!;
        return page.Items.Select(c => c.Title).ToList();
    }

    [Fact]
    public async Task Categories_include_parents_and_leaves_with_parent_ids()
    {
        var client = factory.CreateClient();

        var categories = (await client.GetFromJsonAsync<List<CategoryDto>>("/api/categories"))!;

        var parents = categories.Where(c => c.ParentId is null).Select(c => c.Name).ToList();
        Assert.Equal(new[] { "Sport", "Arts & crafts", "Food & drink", "Media" }, parents);
        var sport = categories.Single(c => c.Name == "Sport");
        Assert.Equal(new[] { "Pilates", "Padel" }, categories.Where(c => c.ParentId == sport.Id).OrderBy(c => c.DisplayOrder).Select(c => c.Name));
    }

    [Fact]
    public async Task Level_filter_accepts_several_values()
    {
        var beginners = await TitlesAsync("levels=beginner");
        Assert.Equal(5, beginners.Count);
        Assert.All(beginners, t => Assert.Contains(t, new[] { "Knitting for beginners", "Pilates 101", "Watercolour basics", "Pilates for beginners", "Padel for beginners" }));

        var advancedOrPro = await TitlesAsync("levels=Advanced,professional");
        Assert.Equal(3, advancedOrPro.Count);
        Assert.Contains("Ceramic bowls", advancedOrPro);
    }

    [Fact]
    public async Task Weekday_and_time_filters_match_sessions()
    {
        var wednesdays = await TitlesAsync("weekdays=3");
        Assert.Equal(new[] { "Padel for beginners", "Cooking - Advanced" }.Order(), wednesdays.Order());

        var byName = await TitlesAsync("weekdays=wednesday");
        Assert.Equal(wednesdays.Order(), byName.Order());

        var mornings = await TitlesAsync("timeFrom=06:00&timeTo=12:00");
        Assert.Equal(new[] { "Pilates 101", "Ceramic bowls", "Street photography walk" }.Order(), mornings.Order());

        var fridayEvening = await TitlesAsync("weekdays=5&timeFrom=16:00");
        Assert.Equal(new[] { "Leather wallet workshop" }, fridayEvening);
    }

    [Fact]
    public async Task Parent_category_expands_to_its_subcategories()
    {
        var sport = await TitlesAsync($"categoryIds={SeedData.CategoryId(SeedData.SportParent)}");
        Assert.Equal(new[] { "Pilates 101", "Pilates for beginners", "Padel for beginners" }.Order(), sport.Order());

        var sportAndMedia = await TitlesAsync($"categoryIds={SeedData.CategoryId(SeedData.SportParent)},{SeedData.CategoryId(8)}");
        Assert.Equal(4, sportAndMedia.Count);
    }

    [Fact]
    public async Task Recommended_puts_hinted_categories_first_and_falls_back_to_popularity()
    {
        var noHint = await TitlesAsync("section=recommended");
        Assert.True(noHint.Count >= 8);
        Assert.Equal("Pilates for beginners", noHint[0]); // 19 enrolled, oldest of the 19s

        var knittingHint = await TitlesAsync($"section=recommended&categoryIds={SeedData.CategoryId(4)}");
        Assert.Equal("Knitting for beginners", knittingHint[0]);
        Assert.Equal(noHint.Count, knittingHint.Count); // hints rank, they do not filter
    }

    [Fact]
    public async Task Invalid_filters_are_rejected_with_field_errors()
    {
        var client = factory.CreateClient();

        var badTime = await client.GetAsync("/api/courses?timeFrom=25:00");
        Assert.Equal(HttpStatusCode.BadRequest, badTime.StatusCode);

        var reversed = await client.GetAsync("/api/courses?timeFrom=18:00&timeTo=09:00");
        Assert.Equal(HttpStatusCode.BadRequest, reversed.StatusCode);

        var badLevel = await client.GetAsync("/api/courses?levels=expert");
        Assert.Equal(HttpStatusCode.BadRequest, badLevel.StatusCode);

        var badDay = await client.GetAsync("/api/courses?weekdays=9");
        Assert.Equal(HttpStatusCode.BadRequest, badDay.StatusCode);
    }

    [Fact]
    public async Task Cards_and_details_carry_the_level()
    {
        var client = factory.CreateClient();

        var details = (await client.GetFromJsonAsync<CourseDetailsDto>($"/api/courses/{SeedData.CourseId(6)}"))!;
        Assert.Equal("Advanced", details.Level);

        var cards = (await client.GetFromJsonAsync<PagedResult<CourseSummaryDto>>("/api/courses?search=photography"))!;
        Assert.Equal("NotApplicable", Assert.Single(cards.Items).Level);
    }
}
