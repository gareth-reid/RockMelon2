namespace RockMelon.Site.ModelBuilder
{
    public interface IBuilder<TM, T>
    {
        TM BuildModel(T test);
        TM BuildModel(int entityId);
        T BuildEntity(TM entity);
        void Delete(int entityId);
        T BuildEntity(int entityId);
        T CopyAndArchive(int original);
    }
}