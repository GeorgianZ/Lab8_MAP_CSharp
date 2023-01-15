namespace Lab_facultativ.repository;

public interface Repository<ID, E>
{
    E findOne(ID id);
    IEnumerable<E> findAll();
}