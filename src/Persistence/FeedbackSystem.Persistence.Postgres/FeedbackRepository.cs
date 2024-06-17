using AutoMapper;
using FeedbackSystem.Domain.Interfaces;
using FeedbackSystem.Domain.Models;
using FeedbackSystem.Persistence.Postgres.Entities;
using FeedbackSystem.Persistence.Postgres.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Persistence.Postgres;

public class FeedbackRepository : IFeedbackRepository
{
    private IDbContextFactory<AppDbContext> _dbContextFactory;
    private readonly IMapper _mapper;

    public FeedbackRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;

        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        _mapper = new Mapper(mappingConfig);
    }

    public async Task AddFeedbackAsync(Feedback feedback)
    {
        try
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

            var entity = _mapper.Map<FeedbackEntity>(feedback);
            entity.CreatedDatetime = DateTime.UtcNow;

            await dbContext.Feedback.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw new Exception($"Could not add feedback by {feedback.CreatedBy}. {exception.Message}");
        }
    }
}
