namespace Arrays
{
    public class Arrays
    {
        public static void Reverse(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                // Intercambiamos los valores en las posiciones left y right
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;

                // Avanzamos los índices hacia el centro
                left++;
                right--;
            }

        }

        public static void Pop(ref int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("El array está vacío, no se puede hacer pop.");
                return;
            }

            // Reducimos el tamaño del array (decrementamos el tamaño lógico)
            Array.Resize(ref array, array.Length - 1);
        }
    
    }

}