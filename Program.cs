Console.WriteLine("Hello, World!");
Console.WriteLine("=== СТЕК ===");
Stack<int> stack = new Stack<int>();
for (int i = 0; i < 11; i++)
{
    stack.Push(i);
}
stack.CheckStack();
for (int i = 0; i < 5; i++)
{
    stack.Pop();
}
stack.CheckStack();

Console.WriteLine("\n=== ОЧЕРЕДЬ ===");
Queue<int> queue = new Queue<int>();
for (int i = 0; i < 11; i++)
{
    queue.Enqueue(i);
}
queue.CheckQueue();
for (int i = 0; i < 11; i++)
{
    queue.Dequeue();
}
queue.CheckQueue();

Console.WriteLine("\n=== СВЯЗАННЫЙ СПИСОК ===");
LinkedList<int> list = new LinkedList<int>();
for (int i = 0; i < 11; i++)
{
    list.Add(i);
}
list.Add(5); // добавим ещё элемент, чтобы в списке было два узла с Data: 5
Console.WriteLine("Связанный список:");
foreach (int i in list)
{
    Console.Write(i+"\t");
}
list.Remove(5); // тогда метод списка должен удалить все элементы, которые имеют Data: 5
list.Remove(6);
Console.WriteLine("\nСвязанный список после удаления элементов 5 и 6:");
foreach (int i in list)
{
    Console.Write(i + "\t");
}

// Класс СТЭК - это такая структура данных, в которой
// данные добавляются и извлекаются по принципу LIFO:
// последний пришел - первый вышел; элемент добавляется
// в конец стека, а при операции извлечения удаляется
// последний элемент стека
class Stack<T>
{
    T[] arr;
    int countOfElems;
    int length;

    public Stack()
    {
        length = 10;
        arr = new T[length];
    }

    public void Push(T value)
    {
        if (arr.Length == countOfElems)
        {
            Console.WriteLine("Ошибка команды PUSH : Переполнение стека");
        }
        else
        {
            countOfElems++;
            arr[countOfElems - 1] = value;
            Console.WriteLine("PUSH : Добавлено новое значение в стек – " + value);
        }
    }

    public void CheckStack()
    {
        if (countOfElems == 0)
        {
            Console.WriteLine("Результат команды CheckStack : Стек пуст");
        }
        else
        {
            Console.WriteLine("Стек:");
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Pop()
    {
        if (countOfElems == 0)
        {
            Console.WriteLine("Ошибка команды POP : Стек пуст");
        }
        else
        {
            T newLastItem = arr[--countOfElems];
            Console.WriteLine("POP : Элемент " + newLastItem + " извлечен из стека");
            arr[countOfElems] = default;
        }
    }

    public void Peek()
    {
        Console.WriteLine("PEEK : Последнее значение стека " + arr[countOfElems - 1]);
    }
}

// Класс ОЧЕРЕДЬ - это такая структура данных, в которой
// новый элемент добавляется в конец последовательности (очереди),
// а при извлечении выбирается первый элемент последовательности (очереди),
// то есть реализуется принцип FIFO - first in first out

// короче говоря, это как СТЕК, но при удалении из очереди
// надо использовать второй временный массив, копирующий элементы исходного,
// и за O(n) в исходный массив переписывают значения из временного
class Queue<T>
{
    T[] arr;
    int countOfElems;
    int length;

    public Queue()
    {
        length = 10;
        arr = new T[length];
    }

    public void Enqueue(T value)
    {
        if (arr.Length == countOfElems)
        {
            Console.WriteLine("Ошибка команды PUSH : Переполнение очереди");
        }
        else
        {
            countOfElems++;
            arr[countOfElems - 1] = value;
            Console.WriteLine("PUSH : Добавлено новое значение в очередь – " + value);
        }
    }

    public void CheckQueue()
    {
        if (countOfElems == 0)
        {
            Console.WriteLine("Результат команды CheckQueue : Очередь пуста");
        }
        else
        {
            Console.WriteLine("Очередь:");
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Dequeue()
    {
        if (countOfElems == 0)
        {
            Console.WriteLine("Ошибка команды POP : Очередь пуста");
        }
        else
        {
            //T newLastItem = arr[--countOfElems];
            T removedItem = arr[0];
            arr[0] = default;

            T[] ar2 = arr;
            int j = 1;
            for (int i = 0; i < length; i++)
            {
                if (j != length)
                {
                    arr[i] = ar2[j++];
                }
                else
                {
                    arr[i] = default;
                    break;
                }
            }

            --countOfElems;
            Console.WriteLine("POP : Элемент " + removedItem + " извлечен из очереди");
        }
    }

    public void Peek()
    {
        Console.WriteLine("PEEK : Первый элемент очереди " + arr[0]);
    }
}

class Node<T>
{
    public Node<T> Next { get; set; }

    public T Data { get; set; }

    public void SetNextNode (Node<T> _nextNode)
    {
        Next = _nextNode;
    }
}

// Класс СВЯЗАННЫЙ СПИСОК – структура данных, в которой
// элементов списка является Узел (Node), хранящий
// данные (data) и информацию о следующем узле (Next)

class LinkedList<T> : IEnumerable<T>
{
    public int Length { get; set; }
    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>();
        newNode.Data = item;

        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Tail.Next = newNode;
        }
        Tail = newNode;
        Console.WriteLine("Элемент "+newNode.Data + " добавлен в список");
        Length++;
    }

    public void Remove(T item)
    {
        Node<T>? current = Head;
        Node<T>? previous = null;

        while (current != null && current.Data != null)
        {
            // данные в узле совпадают с искомыми данными?
            if (current.Data.Equals(item))
            {
                // предыдущый узел известен?
                if (previous != null)
                {
                    // перенаправляем следующую ссылку от предыдущего узла на узел, стоящий после удаляемого
                    previous.Next = current.Next;

                    // если след. узел - хвостовой, то в свойство Tail списка указываем на это
                    if (current.Next == null)
                        Tail = previous;
                }
                else
                {
                    // если у текущего узла нет предыдущего (является головным узлом)
                    // то записываем информацию о следующем узле из свойства Head текущего списка
                    Head = Head?.Next;

                    // если элемент являлся единственным в списке и мы его удалили
                    // то в списке свойства Head и Tail будут иметь значения null
                    if (Head == null)
                        Tail = null;
                }

                // уменьшаем длину списка 
                Length--;
            }

            //переходим на следующий узел списка
            previous = current;
            current = current.Next;
        }
    }

    // очистка списка
    public void Clear()
    {
        Head = null;
        Tail = null;
        Length = 0;
    }

    // поддержка связанным списокм цикла foreach путем реализации интерфейса IEnumerable<T>
    public System.Collections.IEnumerator GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node<T>? current = Head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}