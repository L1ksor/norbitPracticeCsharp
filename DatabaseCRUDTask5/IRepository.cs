namespace DatabaseCRUDTask5
{

    public interface IRepository<T, TId> where T : class
    {
        /// <summary>
        /// Возвращает список всех сущностей из базы данных.
        /// </summary>
        /// <returns>Список объектов типа <typeparamref name="T"/>.</returns>
        List<T> GetAll();

        /// <summary>
        /// Находит и возвращает сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Экземпляр сущности или <c>null</c>, если запись не найдена.</returns>
        T? GetById(TId id);

        /// <summary>
        /// Добавляет новую сущность в базу данных.
        /// </summary>
        /// <param name="entity">Объект сущности для добавления.</param>
        void Add(T entity);

        /// <summary>
        /// Удаляет сущность из базы данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемой сущности.</param>
        void Delete(TId id);

        /// <summary>
        /// Обновляет существующую сущность в базе данных.
        /// </summary>
        /// <param name="entity">Объект сущности с обновленными данными.</param>
        void Update(T entity);
    }
}
