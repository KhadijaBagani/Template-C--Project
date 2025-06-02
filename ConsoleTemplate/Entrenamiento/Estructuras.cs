using System.Globalization;

namespace Structure
{
    public class QueueNode<T> : ValueNode<T>
    {
        public T? Value { get; set; }
        public QueueNode<T>? next { get; set; }

        public QueueNode(T value, QueueNode<T>? next) : base(value)
        {
            this.next = next;
            this.value = value;
        }


    }

    public class MyQueue<T> : IPopable<T>
    {
        /// <summary>
        /// Referencia el primer nodo de la pila
        /// </summary>    
        protected QueueNode<T>? head;
        protected QueueNode<T>? tail;

        /// <summary>
        /// Inserta un valor en el stack
        /// </summary>
        public void Push(T value)
        {
            var old = tail;
            tail = new QueueNode<T>(value, null);
            if (old != null)
            {
                old.next = tail;
            }
            else
            {
                head = tail;
            }

        }

        /// <summary>
        /// Añadir primer valor
        /// </summary>
        public T? First()
        {
            if (head == null)
                return default(T);
            return head.value;
        }

        /// <summary>
        /// Extraer valores y eliminarlos en el proceso
        /// </summary>
        public T? Pop()
        {
            T? resultado = this.First();
            //remove top
            head = head?.next;
            return resultado;
        }
        /// <summary>
        /// Contar longitud de cola
        /// </summary>
        public int Count()
        {
            var node = head;
            // int count = 0;
            // while (node != null && count < 1000)
            // {
            //     node = node.previous;
            //     count += 1;
            // }
            int count;
            for (count = 0; node != null && count < 1000; count++)
            {
                node = node.next;
            }

            return count;
        }

        public void PushRange(ICollection<T> items)
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }

        public bool Contains(T value)
        {
            QueueNode<T>? current = head;

            while (current != null)
            {
                if (Object.Equals(current.Value, value))
                {
                    return true;
                }

                current = current.next;
            }

            return false;
        }

        public int IndexOf(T value)
        {
            QueueNode<T>? current = head;
            int index = 0;

            while (current != null)
            {
                if (Object.Equals(current.Value, value))
                {
                    return index;  // Devuelve el índice cuando se encuentra el valor
                }

                current = current.next;  // Avanzar al siguiente nodo
                index++;  // Incrementar el índice
            }

            return -1;  // Si no se encuentra el valor, devolver -1
        }
    
    }
    

    
  
}
    
