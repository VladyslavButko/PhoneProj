using PhoneMysql.Data.Memento;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace PhoneMysql.Data.Entities
{
    public class MobilePhone
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string storage { get; set; }
        public string RAM { get; set; }
        public double screenSize { get; set; }
        public string camera { get; set; }
        public int batteryCapacity { get; set; }
        public double price { get; set; }

        public MobilePhone() { }


        //builder
        public class Builder
        {
            public string brand;
            public string model;
            public string storage;
            public string RAM;
            public double screenSize;
            public string camera;
            public int batteryCapacity;
            public double price;


            public Builder(string brand, string model, string storage, string RAM, double screenSize, 
                string camera, int batteryCapacity, double price)
            {
                this.brand = brand;
                this.model = model;
                this.storage = storage;
                this.RAM = RAM;
                this.screenSize = screenSize;
                this.camera = camera;
                this.batteryCapacity = batteryCapacity;
                this.price = price;
            }

            public MobilePhone Build()
            {
                // Перевірка перед побудовою
                if (string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(model) || 
                    string.IsNullOrEmpty(storage) || string.IsNullOrEmpty(RAM) ||
                    screenSize != 0.0 || string.IsNullOrEmpty(camera) ||
                    batteryCapacity != 0)
                {
                    throw new InvalidOperationException("ERROR");
                }
                return new MobilePhone(this);
            }
        }
        private MobilePhone(Builder builder)
        {
            brand = builder.brand;
            model = builder.model;
            storage = builder.storage;
            RAM = builder.RAM;
            screenSize = builder.screenSize;
            camera = builder.camera;
            batteryCapacity = builder.batteryCapacity;
            price = builder.price;
        }


        //memento
        private MobilePhone backup;
        public PhoneMemento SaveState()
        {
            return new PhoneMemento(this.MemberwiseClone() as MobilePhone);
        }

        public void RestoreState(PhoneMemento memento)
        {
            this.brand = memento.State.brand;
            this.model = memento.State.model;
            this.storage = memento.State.storage;
            this.RAM = memento.State.RAM;
            this.screenSize = memento.State.screenSize;
            this.camera = memento.State.camera;
            this.batteryCapacity = memento.State.batteryCapacity;
            this.price = memento.State.price;
        }

    }


}