namespace Algoritm.Lesson4
{
    public interface ITree
    {
        TreeNode GetRoot(); // Получить корень дерева

        void AddNode(int value); // добавить узел

        bool RemoveItem(int value); // удалить узел по значению

        TreeNode GetNodeByValue(int value); //получить узел дерева по значению

        void PrintTree(); //вывести дерево в консоль
    }
}
