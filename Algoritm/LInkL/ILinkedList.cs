namespace GeekBrainsTests
{
   // Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList<T>
    {
        int GetCount(); // возвращает количество элементов в списке+
        void AddNode(T value);  // добавляет новый элемент списка+
        void AddNodeAfter(Algoritm.LInkL.LinkedListNode<T> node, T value); //+ добавляет новый элемент списка после определённого элемента
        void RemoveNode(T index); // удаляет элемент по порядковому номеру
        void RemoveNode(Algoritm.LInkL.LinkedListNode<T> node); // удаляет указанный элемент
        Algoritm.LInkL.LinkedListNode<T> FindNode(T searchValue); // ищет элемент по его значению
    }

}
