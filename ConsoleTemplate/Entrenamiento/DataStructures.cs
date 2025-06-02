
namespace Structure
{
    public class ValueNode<T>
    {
        public T value;

        public ValueNode(T value)
        {
            this.value = value;
        }
    }
    public class StackNode<T> : ValueNode<T>
    {
        /// <summary>
        /// Nodo que tiene debajo (null si es el último)
        /// </summary>
        public StackNode<T>? previous;

        public StackNode(T value, StackNode<T>? previous) : base(value)
        {
            this.previous = previous;
        }
    }
    public class MyStack<T> : IContable, IPopable<T>
    {
        /// <summary>
        /// Referencia el primer nodo de la pila
        /// </summary>    
        protected StackNode<T>? head;

        /// <summary>
        /// Inserta un valor en el stack
        /// </summary>
        public void Push(T value)
        {
            head = new StackNode<T>(value, head);
        }

        /// <summary>
        /// Obtiene el "primer" valor del stack (último añadido)
        /// </summary>
        public T? First()
        {
            if (head == null)
                return default(T);
            return head.value;
        }

        /// <summary>
        /// Elimina el primer valor del stack y lo devuelve
        /// </summary>
        public T? Pop()
        {
            T? resultado = this.First();
            //remove top
            head = head?.previous;
            return resultado;
        }
        /// <summary>
        /// Cuenta cuantos valores hay en el stack
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
                node = node.previous;
            }

            return count;
        }
        
    }
    
    /// <summary>
    /// Indica que se puede "contar" el contenido del objeto
    /// </summary>
    public interface IContable
    {
        int Count();
    }
    /// <summary>
    /// Indica que el objeto
    /// </summary>
    public interface IPopable<T>
    { //Interfaz genérica
        /// <summary>
        /// Quita y devuelve el último elemento.
        /// </summary>
        /// <returns>El último elemento del objeto.</returns>
        T? Pop();
        void Push(T value);
        T? First();

    }

}