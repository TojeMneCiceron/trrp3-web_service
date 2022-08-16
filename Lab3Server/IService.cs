using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface ILab3Service
    {
        [OperationContract]
        int GetRowsCount();

        [OperationContract]
        Row GetRow(int i);

        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary.ContractType".
    [DataContract]
    public class Row
    {
        string d_name, description, p_name, o_name, phone, s_name;
        int age;

        public Row() { }
        public Row(string d_name, string description, string p_name, int age, string o_name, string phone, string s_name)
        {
            this.d_name = d_name;
            this.description = description;
            this.p_name = p_name;
            this.o_name = o_name;
            this.phone = phone;
            this.s_name = s_name;
            this.age = age;
        }

        [DataMember]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        //[DataMember]
        //public string StringValue
        //{
        //    get { return stringValue; }
        //    set { stringValue = value; }
        //}

        [DataMember]
        public string D_name { get => d_name; set => d_name = value; }
        [DataMember]
        public string Description { get => description; set => description = value; }
        [DataMember]
        public string P_name { get => p_name; set => p_name = value; }
        [DataMember]
        public string O_name { get => o_name; set => o_name = value; }
        [DataMember]
        public string Phone { get => phone; set => phone = value; }
        [DataMember]
        public string S_name { get => s_name; set => s_name = value; }
    }
}
