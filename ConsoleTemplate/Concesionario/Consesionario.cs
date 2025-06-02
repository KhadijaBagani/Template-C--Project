namespace Concesionario {
    /// <summary>
    /// Clase que define las características de los coches
    /// </summary>
    public class Car : Vehicle{
        
        /// <summary>
        /// Número de matrícula (4 números y 3 letras), null si no ha sido matriculado
        /// </summary>
        public string? plateNumber{
            get {
                return _plateNumber;
            }
            set {
                TestMatricular(value);
                _plateNumber = value;
            }
        }
        
        string? _plateNumber;

        /// <summary>
        /// Color/patrón con el que ha sido pintado
        /// </summary>
        public string paint;

        /// <summary>
        /// Modelo de vehículo
        /// </summary>
        public new string? model{  
                get; //Getter público (puede ser leida)
                private set; //Setter privado (no puede ser modificada)
            }
        /// <summary>
        /// Número de kilómetros que tiene el vehículo
        /// </summary>
        public KMCount kmTraveled{
            get;
            private set;
        }

        public override bool HasFuel => throw new NotImplementedException();

        public Car(string model, string paint, string? plateNum = null, float km=0):base(model){
            this.paint = paint;
            this.plateNumber = plateNum;
            this.kmTraveled = new KMCount(km);
        }

        /// <summary>
        /// Asigna la matrícula al vehículo y garantiza que no se asigna una matrícula no válida
        /// </summary>
        /// <param name="plateNumber">Número de matrícula (4 números y 3 letras mayúsculas)</param>
        public void Matricular(string? plateNumber)
        {
            TestMatricular(plateNumber);
            this.plateNumber = plateNumber;
        }

        private void TestMatricular(string? plateNumber)
        {
            if(plateNumber == null)
                return;
            if ( plateNumber.Length == 0)
                throw new Exception("Matrícula no especificada");
            if (plateNumber.Length != 7)
                throw new Exception("Longitud de matrícula inválida");
        }

        
    }

    public class KMCount{
        public float count{
                get;
                private set;
            }
        public KMCount(float count){
            this.count = count;   
        }
         public void AddKm(float count){
            if(count >0)
                this.count += count;
        }
    }

}