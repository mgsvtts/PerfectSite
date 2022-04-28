using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Data.Manufacturers.CPUManufacturers;
using PerfectSite.Data.Manufacturers.GPUManufacturers;
using PerfectSite.Data.Manufacturers.HDDManufacturers;
using PerfectSite.Data.Manufacturers.MotherboardManufacturers;
using PerfectSite.Data.Manufacturers.PhoneManufacturers;
using PerfectSite.Data.Manufacturers.PowerSupplyManufacturers;
using PerfectSite.Data.Manufacturers.RAMManufacturer;
using PerfectSite.Data.Manufacturers.SSDManufacturers;
using PerfectSite.Data.ManufacturersComputerFrameManufacturers;
using PerfectSite.Data.Products;
using PerfectSite.ViewModels.PageSortFilter;
using PerfectSite.ViewModels.Store;
using PerfectSite.ViewModels.Store.ComputerFrames;
using PerfectSite.ViewModels.Store.Computers;
using PerfectSite.ViewModels.Store.CPUs;
using PerfectSite.ViewModels.Store.GPUs;
using PerfectSite.ViewModels.Store.HDDs;
using PerfectSite.ViewModels.Store.Motherboards;
using PerfectSite.ViewModels.Store.Phones;
using PerfectSite.ViewModels.Store.PowerSupplies;
using PerfectSite.ViewModels.Store.RAMs;
using PerfectSite.ViewModels.Store.SSDs;

namespace PerfectSite.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationContext _db;

        public StoreController(ApplicationContext db)
        {
            _db = db;

            if (_db.CPUs.Count() == 0)
            {
                CPUManufacturer intel = new Data.Manufacturers.CPUManufacturers.Intel { Name = "Intel" };
                CPUManufacturer cpu_amd = new Data.Manufacturers.CPUManufacturers.AMD { Name = "AMD" };
                PhoneManufacturer phone_asus = new Data.Manufacturers.PhoneManufacturers.Asus { Name = "Asus" };
                CPUManufacturer baikal = new CPUManufacturer { Name = "Baikal" };

                CPU baikal_t1 = new CPU
                {
                    ModelName = "Baikal-T1",
                    Amount = 100,
                    Cores = 2,
                    Threads = 0,
                    Manufacturer = baikal,
                    PowerUsage = 5,
                    Price = 999_999,
                    Socket = "POWERFUL",
                    Speed = 1.2,
                    BoughtTimes = 0,
                    Description = "Baikal-T1 — российский процессор семейства Baikal, созданный российской бесфабричной компанией Baikal Electronics с использованием двух 32-битных процессорных ядер P5600 архитектуры MIPS32 Release 5 от компании Imagination Technologies."
                };

                CPU ryzen_5_3600 = new CPU
                {
                    ModelName = "Ryzen 5 3600",
                    Amount = 200,
                    Cores = 6,
                    Threads = 12,
                    Manufacturer = cpu_amd,
                    PowerUsage = 65,
                    Price = 12_000,
                    Socket = "AM4",
                    Speed = 3.6,
                    BoughtTimes = 0,
                    Description = "AMD Ryzen 5 3600 – шестиядерный процессор, который устанавливается в геймерские и рабочие компьютеры. Модель отвечает за высокую производительность системы, ее быструю загрузку," +
                    "а также обеспечивает эффективность многозадачного режима. Устройство поддерживает систему Wraith Stealth, отвечающую за охлаждение и предотвращающую перегрев." +
                    "Рабочая частота AMD Ryzen 5 3600 составляет 3,6 ГГц, но в режиме Turbo она увеличивается до 4,2 ГГц, что приводит к увеличению мощности ПК. Процессор совместим с двухканальной оперативной памятью DDR4."
                };
                CPU i5_9400f = new CPU
                {
                    ModelName = "Intel Core I5-9400F",
                    Amount = 150,
                    Cores = 6,
                    Threads = 6,
                    Manufacturer = intel,
                    PowerUsage = 65,
                    Price = 11_000,
                    Socket = "LGA 1151-v2",
                    Speed = 4.100,
                    BoughtTimes = 1,
                    Description = "INTEL Core i5 9400F – шестиядерный процессор, который подойдет для геймерских и офисных компьютеров, нуждающихся в мощности и производительности для решения сложных задач и работы в ресурсоемких программах и приложениях." +
                    "Модель с разъемом LGA 1151v2 совместима с двухканальной оперативной памятью DDR4, максимальный объем которой может составлять 128 Гб." +
                    "INTEL Core i5 9400F поддерживает несколько технологий и функций: Thermal Monitoring Technologies, которая снижает тепловыделение и предотвращает перегрев, Identity Protection Technology, обеспечивающую безопасность персональных данных и конфиденциальность хранящейся информации, Optane Memory Supported, повышающую ресурсы системы."
                };

                CPU i3_10100F = new CPU
                {
                    ModelName = "Intel Core i3 10100F",
                    Amount = 500,
                    Cores = 4,
                    Threads = 8,
                    Manufacturer = intel,
                    PowerUsage = 65,
                    Price = 12_500,
                    Socket = "LGA 1200",
                    Speed = 3.6,
                    BoughtTimes = 2,
                    Description = "Четырехъядерный процессор INTEL Core i3 10100F имеет ядро Comet Lake и обеспечивает работу в 8 потоках. Функционирует с частотой 4.3 ГГц в режиме Turbo, используя L3 кэш объемом 6 Мб." +
                    "В устройстве используется заблокированный множитель. Шина обеспечивает пропускную способность в 8 GT/s. Поддерживается память DDR4, объем которой может быть до 128 Гб." +
                    "Процессор INTEL Core i3 10100F корректно работает при температуре до 100 градусов. Его тепловыделение составляет всего 65 Вт. Применяется также контроллер PCI Express версии 3.0. Графическое ядро в процессоре отсутствует."
                };

                CPU core_i9_11900 = new CPU
                {
                    ModelName = "Intel Core i9 11900KF",
                    Amount = 260,
                    Cores = 8,
                    Threads = 16,
                    Speed = 5.3,
                    PowerUsage = 125,
                    Manufacturer = intel,
                    Price = 56_999.99M,
                    Socket = "LGA 1200",
                    BoughtTimes = 110
                };

                CPU ryzen_5_5600G = new CPU
                {
                    ModelName = "Ryzen 5 5600G",
                    Amount = 25,
                    Cores = 6,
                    Threads = 12,
                    Manufacturer = cpu_amd,
                    PowerUsage = 65,
                    Price = 24_000,
                    Socket = "AM4",
                    Speed = 3.9,
                    BoughtTimes = 5,
                    Description = "Универсальный процессор AMD Ryzen 5 5600X подойдет для сборки игрового или профессионального рабочего компьютера. Он отличается высокой вычислительной мощностью. Чип основан на ядре Vermeer с применением технологического процесса 7 нм. При установке на материнскую плату применяется сокет AM4. Модель предусматривает 6 ядер и 12 потоков, а также обладает кэшом L3 объемом 32 Мб." +
                    "Удобный в использовании процессор AMD Ryzen 5 5600X имеет поддержку памяти типа DDR4 с 2 каналами. Графическое ядро отсутствует, поэтому пользователю важно самостоятельно подобрать видеокарту. Тепловыделение процессора достигает 65 Вт, что важно учитывать при выборе системы охлаждения. Ведь кулер в комплектацию данной модели не входит."
                };

                PhoneManufacturer apple = new PhoneManufacturer { Name = "Apple" };
                PhoneManufacturer samsung = new PhoneManufacturer { Name = "Samsung" };
                PhoneManufacturer xiaomi = new PhoneManufacturer { Name = "Xiaomi" };
                Phone zenfone_5z = new Phone
                {
                    ModelName = "Zenfone 5Z",
                    Amount = 125,
                    Manufacturer = phone_asus,
                    Price = 25_000
                };

                Phone iPhone_12_256gb = new Phone
                {
                    ModelName = "Apple iPhone 12 256Gb",
                    Amount = 10,
                    BoughtTimes = 0,
                    Manufacturer = apple,
                    Price = 83_990
                };

                Phone galaxy_z_flip3_8 = new Phone
                {
                    ModelName = " Galaxy Z Flip3 8",
                    Manufacturer = samsung,
                    BoughtTimes = 0,
                    Price = 94_990,
                };
                Phone xiaomi_12x_8 = new Phone
                {
                    ModelName = "Xiaomi 12X 8",
                    Manufacturer = xiaomi,
                    BoughtTimes = 0,
                    Price = 79_990
                };
                Data.Manufacturers.ComputerFrameManufacturers.AeroCool frame_aerocool = new Data.Manufacturers.ComputerFrameManufacturers.AeroCool { Name = "AeroCool" };

                Zalman zalman = new Zalman { Name = "Zalman" };
                CoolerMaster coolerMaster = new CoolerMaster { Name = "Cooler Master" };
                Data.ManufacturersComputerFrameManufacturers.Thermaltake thermaltake = new Data.ManufacturersComputerFrameManufacturers.Thermaltake { Name = "Thermaltake" };
                ComputerFrame quartz_revo = new ComputerFrame
                {
                    ModelName = "Quartz REVO",
                    Manufacturer = frame_aerocool,
                    Amount = 50,
                    Price = 8_000.99M,
                    GPULength = 360,
                    Size = "ATX",
                    BoughtTimes = 50
                };

                ComputerFrame cs_109_white = new ComputerFrame
                {
                    ModelName = "CS-109 White",
                    Manufacturer = frame_aerocool,
                    Amount = 10,
                    Price = 14_999.99M,
                    GPULength = 260,
                    Size = "MINI Tower",
                    BoughtTimes = 110
                };

                ComputerFrame z11_plus_black = new ComputerFrame
                {
                    ModelName = "Z11 Plus Black",
                    Manufacturer = zalman,
                    Amount = 5,
                    Price = 7_499.99M,
                    GPULength = 290,
                    Size = "MIDI Tower",
                    BoughtTimes = 0
                };
                ComputerFrame mastercase_h100_iron_grey_argb = new ComputerFrame
                {
                    ModelName = "MasterCase H100 Iron Grey ARGB",
                    Manufacturer = coolerMaster,
                    Amount = 20,
                    Price = 5530,
                    GPULength = 210,
                    Size = "Micro-Tower",
                    BoughtTimes = 0
                };

                ComputerFrame ah_t600_snow_full_tower_chassis = new ComputerFrame
                {
                    ModelName = "AH T600 Snow Full Tower Chassis",
                    Manufacturer = thermaltake,
                    Amount = 15,
                    Price = 15599,
                    GPULength = 440,
                    Size = "Full Tower",
                    BoughtTimes = 0
                };

                GPUManufacturer nvidia = new GPUManufacturer { Name = "Nvidia" };
                GPUManufacturer gpu_amd = new GPUManufacturer { Name = "AMD" };

                GPU rtx_3080Ti = new GPU
                {
                    ModelName = "Nvidia RTX 3080 Ti",
                    Manufacturer = nvidia,
                    Amount = 5,
                    Price = 217_000,
                    Size = 320,
                    MemorySize = 12,
                    MemoryFrequency = 1900,
                    GPUFrequency = 1710,
                    MemoryType = "GDDR6X",
                    BoughtTimes = 0,
                    Description = "Эффективная видеокарта Gigabyte NVIDIA GeForce RTX 3080TI подойдет для любого геймера. Производитель оснастил ее системой охлаждения в виде одного 80-мм и двух 90-мм вентиляторов, отличающихся уникальной конфигурацией лопастей. Вращение центрального вентилятора осуществляется в альтернативном направлении." +
                    "Благодаря уникальной технологии Alternate Spinning видеокарта Gigabyte NVIDIA GeForce RTX 3080TI отличается ощутимо сниженным негативным эффектом турбулентности. В рассматриваемой модели возможно существенное наращивание давления воздушного потока. Реализована полупассивная схема охлаждения, при которой вентиляторы неактивны, если нагрузка на ГП низкая, в том числе, и при играх, которые не отличаются требовательностью к аппаратным ресурсам."
                };

                GPU rx_6900_xt = new GPU
                {
                    ModelName = "Radeon RX 6900XT",
                    Manufacturer = gpu_amd,
                    Amount = 7,
                    Price = 158_990,
                    Size = 286,
                    MemorySize = 16,
                    MemoryFrequency = 1600,
                    GPUFrequency = 2015,
                    MemoryType = "GDDR6",
                    BoughtTimes = 1,
                    Description = "Высокопроизводительная игровая видеокарта MSI AMD Radeon RX 6900XT отличается отменными характеристиками, обеспечивающими качественное изображение игровых эпизодов и продуктивность работы при выполнении различных операций. Частота графического процессора составляет 2235 МГц, она может достигать 2425 МГц в режиме Boost." +
                    "В системе охлаждения видеокарты MSI AMD Radeon RX 6900XT используются три вентилятора и радиатор. Дополнительное охлаждение производится с помощью тепловых трубок. Производители рекомендуют использовать блок питания мощностью не менее 850 Вт."
                };

                GPU rtx_3080 = new GPU
                {
                    ModelName = "Nvidia RTX 3080",
                    Manufacturer = nvidia,
                    Amount = 15,
                    Price = 147_990,
                    Size = 305,
                    MemorySize = 10,
                    MemoryFrequency = 1900,
                    GPUFrequency = 1740,
                    MemoryType = "GDDR6X",
                    BoughtTimes = 5
                };

                GPU rtx_3070_ti = new GPU
                {
                    ModelName = "Nvidia RTX 3070 Ti",
                    Manufacturer = nvidia,
                    Amount = 25,
                    Price = 125_990,
                    Size = 294,
                    MemorySize = 8,
                    MemoryFrequency = 1900,
                    GPUFrequency = 1575,
                    MemoryType = "GDDR6X",
                    BoughtTimes = 9,
                    Description = "Невероятно потрясающая графика, которую обеспечивает видеокарта Palit NVIDIA GeForce RTX 3070TI, сочетается с высокой частотой кадров и возможностями искусственного интеллекта. Модель окажется оптимальным выбором для игр, а также для работы в творческих приложениях. Производитель использует высококлассные пластины из алюминия, которые обеспечивают достойное охлаждение." +
                    "Производитель, создавая видеокарту Palit NVIDIA GeForce RTX 3070TI, использовал собственную запатентованную технологию. Тепловые трубки в виде двойной буквы U изготовлены под оптимальным углом и обладают двойным изгибом. Это позволило увеличить площадь рассеивания тепла на 20% и на 5 градусов снизить максимальную температуру графического процессора."
                };

                GPU rtx_3070 = new GPU
                {
                    ModelName = "Nvidia RTX 3070",
                    Manufacturer = nvidia,
                    Amount = 45,
                    Price = 92_990,
                    Size = 304,
                    MemorySize = 8,
                    MemoryFrequency = 1400,
                    GPUFrequency = 1500,
                    MemoryType = "GDDR6",
                    BoughtTimes = 75
                };

                GPU rtx_3060 = new GPU
                {
                    ModelName = "Nvidia RTX 3060",
                    Manufacturer = nvidia,
                    Amount = 105,
                    Price = 77_990,
                    Size = 245,
                    MemorySize = 12,
                    MemoryFrequency = 1500,
                    GPUFrequency = 1320,
                    MemoryType = "GDDR6",
                    BoughtTimes = 110
                };

                GPU rx_6800_xt = new GPU
                {
                    ModelName = "Radeon RX 6800XT",
                    Manufacturer = gpu_amd,
                    Amount = 15,
                    Price = 145_990,
                    Size = 324,
                    MemorySize = 16,
                    MemoryFrequency = 1600,
                    GPUFrequency = 2015,
                    MemoryType = "GDDR6",
                    BoughtTimes = 30
                };

                GPU rx_5600_xt = new GPU
                {
                    ModelName = "Radeon RX 5600XT",
                    Manufacturer = gpu_amd,
                    Amount = 25,
                    Price = 65_990,
                    Size = 231,
                    MemorySize = 6,
                    MemoryFrequency = 1200,
                    GPUFrequency = 1185,
                    MemoryType = "GDDR6",
                    BoughtTimes = 110
                };

                GPU rx_6700_xt = new GPU
                {
                    ModelName = "Radeon RX 6700XT",
                    Manufacturer = gpu_amd,
                    Amount = 200,
                    Price = 99_990,
                    Size = 295,
                    MemorySize = 12,
                    MemoryFrequency = 1600,
                    GPUFrequency = 2474,
                    MemoryType = "GDDR6",
                    BoughtTimes = 60
                };

                GPU rx_6500_xt = new GPU
                {
                    ModelName = "Radeon RX 6500XT",
                    Manufacturer = gpu_amd,
                    Amount = 500,
                    Price = 34_000,
                    Size = 282,
                    MemorySize = 4,
                    MemoryFrequency = 1800,
                    GPUFrequency = 2685,
                    MemoryType = "GDDR6",
                    BoughtTimes = 0
                };
                HDDManufacturer seagate = new HDDManufacturer { Name = "Seagate" };
                HDDManufacturer toshiba = new HDDManufacturer { Name = "Toshiba" };
                HDDManufacturer wd = new HDDManufacturer { Name = "WD" };

                HDD exos_X20_st20000nm007d = new HDD
                {
                    ModelName = "Seagate Exos X20 ST20000NM007D",
                    Manufacturer = seagate,
                    Amount = 50,
                    Price = 97_990,
                    Bandwidth = 285,
                    FormFactor = 3.5,
                    Interface = "SATA III",
                    BoughtTimes = 50
                };

                HDD blue_wd5000azlx = new HDD
                {
                    ModelName = "WD Blue WD5000AZLX",
                    Manufacturer = wd,
                    Amount = 75,
                    Price = 4400,
                    Bandwidth = 150,
                    FormFactor = 3.5,
                    Interface = "SATA III",
                    BoughtTimes = 200,
                    Description = "Если вы ищете оптимальное устройство с отличными показателями работоспособности для рабочего и настоящего компьютера, то стоит обратить внимание на жесткий диск WD Blue WD5000AZLX. Накопитель от производителя с мировым именем отличается высоким качеством изготовления, что гарантирует надежность и долговечность. Устройство выполнено в форм-факторе 3,5 дюйма и имеет толщину 25,4 мм. Жесткий диск WD Blue WD5000AZLX вмещает в себя до 500 Гб данных, например, рабочих документов, фотографий и фильмов. Инсталляция в систему компьютера реализовано посредством интерфейса последнего поколения SATA III, а для обеспечения отличной производительности предназначены 32 Мб буферной памяти. Скорость вращения шпинделя равна максимальным 7200 оборотов в минуту для мгновенных записи и отклика файлов, чтобы сэкономить ваше время."
                };

                HDD enterprise_capacity_mg09ava18te = new HDD
                {
                    ModelName = "Toshiba Enterprise Capacity MG09ACA18TE",
                    Manufacturer = toshiba,
                    Amount = 70,
                    Price = 88_990,
                    Bandwidth = 281,
                    FormFactor = 3.5,
                    Interface = "SATA III",
                    BoughtTimes = 75
                };

                MotherboardManufacturer motherboard_asus = new MotherboardManufacturer { Name = "Asus" };
                MotherboardManufacturer asrock = new MotherboardManufacturer { Name = "ASRock" };
                MotherboardManufacturer gigabyte = new MotherboardManufacturer { Name = "GIGABYTE" };
                MotherboardManufacturer msi = new MotherboardManufacturer { Name = "MSI" };

                Motherboard trx40_aorus_pro_wifi = new Motherboard
                {
                    ModelName = "GIGABYTE TRX40 AORUS PRO WIFI",
                    Amount = 400,
                    FormFactor = "ATX",
                    Manufacturer = gigabyte,
                    MemorySlots = 8,
                    MemoryType = "DDR4",
                    Socket = "sTRX4",
                    Price = 36_700,
                    BoughtTimes = 0
                };

                Motherboard z490_a_pro = new Motherboard
                {
                    ModelName = "MSI Z490-A PRO",
                    Amount = 5,
                    FormFactor = "ATX",
                    Manufacturer = msi,
                    MemorySlots = 4,
                    MemoryType = "DDR4",
                    Socket = "LGA 1200",
                    BoughtTimes = 0,
                    Price = 16_799
                };

                Motherboard rog_maximus_z690_apex = new Motherboard
                {
                    ModelName = "Asus ROG MAXIMUS Z690 APEX",
                    Amount = 250,
                    FormFactor = "ATX",
                    Manufacturer = motherboard_asus,
                    MemorySlots = 2,
                    MemoryType = "DDR5",
                    Socket = "LGA 1700",
                    BoughtTimes = 0,
                    Price = 70_080
                };

                Motherboard b450m_hdv_r4_0 = new Motherboard
                {
                    ModelName = "ASROCK B450M-HDV R4.0",
                    Amount = 25,
                    Manufacturer = asrock,
                    MemorySlots = 2,

                    MemoryType = "DDR4",
                    FormFactor = "mATX",
                    Price = 2850,
                    Socket = "AM4",
                    BoughtTimes = 15,
                    Description = "Высокую производительность стационарного компьютера обеспечит материнская плата ASROCK B450M-HDV R4.0, выполненная в форм-факторе Micro-ATX. Ее можно установить в подавляющее большинство существующих корпусов. Использованная технология ASRock Full Spike Protection убережет ее от внезапных скачков напряжения, избавив от сбоев в работе всей системы. Устройство сконструировано на чипсете AMD B450, в котором предусмотрены два слота под плашки оперативной памяти DDR4-типа с частотой в диапазоне от 2133 МГц до 3200 МГц. Их суммарный объем может достигать 32 Гб." +
                    "Материнская плата ASROCK B450M-HDV R4.0 является отличным компаньоном для процессора от фирмы AMD. Для его подключения используется сокет AM4. Для видеокарты предусмотрен защищенный от помех слот PCI-E x16. Применение звуковой схемы 7.1 и поддержка звука Realtek HD Audio гарантируют качественное и насыщенное звуковое сопровождение с эффектом объемного звучания."
                };

                PowerSupplyManufacturer aerocool = new PowerSupplyManufacturer { Name = "AeroCool" };
                PowerSupplyManufacturer be_quiet = new PowerSupplyManufacturer { Name = "Be Quiet!" };
                PowerSupplyManufacturer corsair = new PowerSupplyManufacturer { Name = "Corsair" };
                PowerSupplyManufacturer powerSupply_thermaltake = new PowerSupplyManufacturer { Name = "Thermaltake" };

                PowerSupply kcas_plus_700 = new PowerSupply
                {
                    ModelName = "Aerocool KCAS PLUS 700",
                    Manufacturer = aerocool,
                    Amount = 60,
                    BoughtTimes = 50,
                    Certificate = "80 PLUS BRONZE",
                    Power = 700,
                    Price = 5100,
                    Description = "Блок питания AEROCOOL KCAS PLUS 700 отличается оптимальным сочетанием цены и возможностей. Кроме того, характеризуется высокой степенью энергоэффективности и подходит для различных систем. БП выполнен в черном металлическом корпусе со съемной крышкой. Для охлаждения применяется 120 мм вентилятор, обороты которого регулируются. Это позволяет минимизировать вероятность перегрева. При покупке стоит учитывать, что номинальная мощность составляет 700 Вт." +
                    "AEROCOOL KCAS PLUS 700 укомплектован набором кабелей. Это гарантирует надежное и безопасное подключение элементов системы. В комплекте также имеются крепежные винты, обеспечивающие надежную фиксацию блока. Достоинством данного БП считается высокий уровень КПД, степень защиты, удобство монтажа и малошумность."
                };

                PowerSupply hxi1200 = new PowerSupply
                {
                    ModelName = "Corsair HXi1200",
                    Manufacturer = corsair,
                    Amount = 55,
                    Certificate = "80 PLUS PLATINUM",
                    Power = 1200,
                    Price = 30_140,
                    BoughtTimes = 0,
                    Description = "Блок питания CORSAIR HX Series™ отличается высокой эффективностью, подтвержденной сертификацией 80 PLUS PLATINUM, чрезвычайно точной регулировкой напряжения и режимом нулевой скорости вращения вентилятора Zero RPM, что обеспечивает практически бесшумную работу."
                };

                PowerSupply dark_power_pro_12 = new PowerSupply
                {
                    ModelName = "DARK POWER PRO 12",
                    Manufacturer = be_quiet,
                    Amount = 100,
                    BoughtTimes = 0,
                    Certificate = "80 PLUS TITANIUM",
                    Power = 1500,
                    Price = 47_999,
                    Description = "be quiet! Dark Power Pro 12 1500W с эффективностью 80 PLUS® Titanium и производительностью мирового класса благодаря полностью цифровому управлению и бескаркасной концепции вентилятора."
                };

                PowerSupply toughpower_pf1_argb = new PowerSupply
                {
                    ModelName = "Thermaltake Toughpower PF1 ARGB",
                    Manufacturer = powerSupply_thermaltake,
                    Amount = 1000,
                    BoughtTimes = 0,
                    Certificate = "80 PLUS PLATINUM",
                    Power = 1050,
                    Price = 24_700,
                    Description = "Полностью модульный БП соответствующий стандарту 80 PLUS Platinum аналогового типа с вентилятором имеющим подсветку состоящей из 18 RGB адресных светодиодов."
                };

                RAMManufacturer kingston = new RAMManufacturer { Name = "Kingston" };
                RAMManufacturer ram_corsair = new RAMManufacturer { Name = "Corsair" };
                RAMManufacturer gskill = new RAMManufacturer { Name = "G.Skill" };
                RAMManufacturer ram_samsung = new RAMManufacturer { Name = "Samsung" };

                RAM dominator_platimun_rgb_cmt32gx5m2b5600c36_ddr5 = new RAM
                {
                    ModelName = "Corsair DOMINATOR PLATINUM RGB CMT32GX5M2B5600C36 DDR5",
                    Manufacturer = ram_corsair,
                    Amount = 100,
                    MemorySize = 16,
                    Speed = 5600,
                    Price = 41_990,
                    BoughtTimes = 0
                };

                RAM m378a5244cb0_cwe_ddr4 = new RAM
                {
                    ModelName = "Samsung M378A5244CB0-CWE DDR4",
                    Manufacturer = ram_samsung,
                    Amount = 200,
                    MemorySize = 4,
                    Speed = 3200,
                    Price = 1990,
                    BoughtTimes = 0
                };

                RAM trident_z5 = new RAM
                {
                    ModelName = "G.Skill TRIDENT Z5",
                    Manufacturer = gskill,
                    Amount = 180,
                    MemorySize = 32,
                    Speed = 5600,
                    Price = 47990,
                    BoughtTimes = 0,
                    Description = "Оперативная память G.Skill TRIDENT Z5, представляющая из себя комплект из двух модулей по 16 ГБ, рассчитана на интенсивный характер эксплуатации в составе игрового системного блока высокого класса. Справиться с повышенной теплоотдачей способны массивные радиаторы оригинальной конструкции, предусмотренные конструкцией модулей. Тип памяти – DDR5. Устройство способно проявить себя и в составе мощного компьютера универсального назначения."
                };
                RAM fury_beast_black_kf426c16bb_8 = new RAM
                {
                    ModelName = "Kingston Fury Beast Black KF426C16BB/8",
                    Manufacturer = kingston,
                    Amount = 75,
                    MemorySize = 8,
                    Speed = 2666,
                    Price = 3800,
                    BoughtTimes = 0
                };

                SSDManufacturer ssd_samsung = new SSDManufacturer { Name = "Samsung" };
                SSDManufacturer ssd_intel = new SSDManufacturer { Name = "Intel" };
                SSDManufacturer sanDisk = new SSDManufacturer { Name = "SanDisk" };
                SSD dc_d3_s4510_ssdsc2kb038t801_3_8 = new SSD
                {
                    ModelName = "Intel DC D3-S4510 SSDSC2KB038T801 3.8ТБ",
                    Manufacturer = ssd_intel,
                    Amount = 250,
                    FormFactor = 2.5,
                    Bandwidth = 560,
                    Interface = "SATA III",
                    BoughtTimes = 0,
                    Price = 139_990,
                    Description = "Сочетая в себе высокую производительность и низкое энергопотребление SSD накопитель INTEL DC D3-S4510 SSDSC2KB038T801 способен улучшить эффективность работы центров обработки данных. Представленная модель выделяется высоким качеством и экономичностью. Идеально подходит для использования в компьютерной технике при необходимости проведения видеоконференций или для обработки большого объема информации."
                };

                SSD _870_evo_mz_77e250bw = new SSD
                {
                    ModelName = "Samsung 870 EVO MZ-77E250BW",
                    Manufacturer = ssd_samsung,
                    Amount = 200,
                    FormFactor = 2.5,
                    Bandwidth = 530,
                    Interface = "SATA III",
                    BoughtTimes = 110,
                    Price = 11_500,
                    Description = "Покупатели нередко заказывают SSD накопитель SAMSUNG 870 EVO MZ-77E250BW, потому что представленное устройство обладает необходимыми характеристиками и большими возможностями в контексте удобной эксплуатации. Время наработки на отказ достигает 1500000 ч. Объема памяти в 250 Гб будет достаточно, чтобы установить ОС, вспомогательный софт, хранить информацию." +
                    "Представленный SSD накопитель SAMSUNG 870 EVO MZ-77E250BW работает бесшумно, потребляет незначительное количество энергии – 3.5 Вт (в режиме ожидания 0.03 Вт), имеет память типа 3D TLC и функционирует при помощи оригинального контроллера Samsung MGX. Перечисленные характеристики положительно влияют на скорость чтения и записи информации. Распространенный интерфейс SATA III обеспечит покупателю удобное подключение SSD к компьютеру, ноутбуку или другой технике."
                };

                SSD sandisk_2_5_ultra_3d_2tb = new SSD
                {
                    ModelName = "SanDisk 2.5 Ultra 3D 2TB",
                    Manufacturer = sanDisk,
                    Amount = 100,
                    FormFactor = 2.5,
                    Bandwidth = 560,
                    Interface = "SATA III",
                    BoughtTimes = 0,
                    Price = 26_000,
                };

                Computer my_pc = new Computer
                {
                    CPU = ryzen_5_3600,
                    GPU = rx_5600_xt,
                    Frame = quartz_revo,
                    RAM = fury_beast_black_kf426c16bb_8,
                    HDD = blue_wd5000azlx,
                    ModelName = "Лучший компьютер этой вселенной",
                    Motherboard = b450m_hdv_r4_0,
                    SSD = _870_evo_mz_77e250bw,
                    PowerSupply = kcas_plus_700,
                    Amount = 1,
                    Price = 0,
                    BoughtTimes = 0,
                    Description = "Компьютер, на котором был написан этот сайт"
                };
                _db.GPUs.AddRange(rx_6700_xt, rx_6800_xt, rx_6900_xt, rtx_3060, rtx_3070, rtx_3070_ti, rtx_3080, rtx_3080Ti, rx_5600_xt, rx_6500_xt);
                _db.GPUManufacturers.AddRange(gpu_amd, nvidia);
                _db.CPUManufacturers.AddRange(intel, cpu_amd);
                _db.RAMs.AddRange(fury_beast_black_kf426c16bb_8, dominator_platimun_rgb_cmt32gx5m2b5600c36_ddr5, m378a5244cb0_cwe_ddr4, trident_z5);
                _db.RAMManufacturers.Add(kingston);
                _db.Computers.Add(my_pc);
                _db.HDDs.AddRange(blue_wd5000azlx, enterprise_capacity_mg09ava18te, exos_X20_st20000nm007d);
                _db.HDDManufacturers.AddRange(wd, seagate);
                _db.SSDs.AddRange(_870_evo_mz_77e250bw, sandisk_2_5_ultra_3d_2tb, dc_d3_s4510_ssdsc2kb038t801_3_8);
                _db.SSDManufacturers.Add(ssd_samsung);
                _db.Motherboards.AddRange(b450m_hdv_r4_0, rog_maximus_z690_apex, trx40_aorus_pro_wifi, z490_a_pro);
                _db.MotherboardManufacturers.AddRange(asrock, motherboard_asus);
                _db.PowerSupplies.AddRange(kcas_plus_700, hxi1200, dark_power_pro_12, toughpower_pf1_argb);
                _db.CPUs.AddRange(ryzen_5_3600, i5_9400f, i3_10100F, ryzen_5_5600G, core_i9_11900, baikal_t1);
                _db.PowerSupplyManufacturers.Add(aerocool);
                _db.Phones.AddRange(zenfone_5z, iPhone_12_256gb, xiaomi_12x_8, galaxy_z_flip3_8);
                _db.PhoneManufacturers.Add(phone_asus);
                _db.ComputerFrames.AddRange(quartz_revo, cs_109_white, z11_plus_black, mastercase_h100_iron_grey_argb, ah_t600_snow_full_tower_chassis);

                _db.SaveChanges();
            }
        }

        public async Task<IActionResult> CPUs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<CPU> cpus = _db.CPUs.Include(p => p.Manufacturer);

            ControllerActions<CPU> actions = new ControllerActions<CPU>(cpus);

            cpus = actions.AddFilter(manufacturer, name);

            cpus = actions.AddSort(sortOrder);

            (int count, page, List<CPU> items) = actions.AddPagination(page).Result;

            ProductViewModel<CPU> viewModel = new ProductViewModel<CPU>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new CPU_FilterViewModel(await _db.CPUManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Frames(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<ComputerFrame> frames = _db.ComputerFrames.Include(p => p.Manufacturer);

            ControllerActions<ComputerFrame> actions = new ControllerActions<ComputerFrame>(frames);

            frames = actions.AddFilter(manufacturer, name);

            frames = actions.AddSort(sortOrder);

            (int count, page, List<ComputerFrame> items) = actions.AddPagination(page).Result;

            ProductViewModel<ComputerFrame> viewModel = new ProductViewModel<ComputerFrame>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new ComputerFrame_FilterViewModel(await _db.ComputerFrameManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Phones(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Phone> phones = _db.Phones.Include(p => p.Manufacturer);

            ControllerActions<Phone> actions = new ControllerActions<Phone>(phones);

            phones = actions.AddFilter(manufacturer, name);

            phones = actions.AddSort(sortOrder);

            (int count, page, List<Phone> items) = actions.AddPagination(page).Result;

            ProductViewModel<Phone> viewModel = new ProductViewModel<Phone>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new Phone_FilterViewModel(await _db.PhoneManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> GPUs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<GPU> gpus = _db.GPUs.Include(p => p.Manufacturer);

            ControllerActions<GPU> actions = new ControllerActions<GPU>(gpus);

            gpus = actions.AddFilter(manufacturer, name);

            gpus = actions.AddSort(sortOrder);

            (int count, page, List<GPU> items) = actions.AddPagination(page).Result;

            ProductViewModel<GPU> viewModel = new ProductViewModel<GPU>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new GPU_FilterViewModel(await _db.GPUManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> HDDs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<HDD> hdds = _db.HDDs.Include(p => p.Manufacturer);

            ControllerActions<HDD> actions = new ControllerActions<HDD>(hdds);

            hdds = actions.AddFilter(manufacturer, name);

            hdds = actions.AddSort(sortOrder);

            (int count, page, List<HDD> items) = actions.AddPagination(page).Result;

            ProductViewModel<HDD> viewModel = new ProductViewModel<HDD>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new HDD_FilterViewModel(await _db.HDDManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Motherboards(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Motherboard> motherboards = _db.Motherboards.Include(p => p.Manufacturer);

            ControllerActions<Motherboard> actions = new ControllerActions<Motherboard>(motherboards);

            motherboards = actions.AddFilter(manufacturer, name);

            motherboards = actions.AddSort(sortOrder);

            (int count, page, List<Motherboard> items) = actions.AddPagination(page).Result;

            ProductViewModel<Motherboard> viewModel = new ProductViewModel<Motherboard>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new Motherboard_FilterViewModel(await _db.MotherboardManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PowerSupplies(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<PowerSupply> powerSupplies = _db.PowerSupplies.Include(p => p.Manufacturer);

            ControllerActions<PowerSupply> actions = new ControllerActions<PowerSupply>(powerSupplies);

            powerSupplies = actions.AddFilter(manufacturer, name);

            powerSupplies = actions.AddSort(sortOrder);

            (int count, page, List<PowerSupply> items) = actions.AddPagination(page).Result;

            ProductViewModel<PowerSupply> viewModel = new ProductViewModel<PowerSupply>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new PowerSupply_FilterViewModel(await _db.PowerSupplyManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> RAMs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<RAM> rams = _db.RAMs.Include(p => p.Manufacturer);

            ControllerActions<RAM> actions = new ControllerActions<RAM>(rams);

            rams = actions.AddFilter(manufacturer, name);

            rams = actions.AddSort(sortOrder);

            (int count, page, List<RAM> items) = actions.AddPagination(page).Result;

            ProductViewModel<RAM> viewModel = new ProductViewModel<RAM>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new RAM_FilterViewModel(await _db.RAMManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> SSDs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<SSD> rams = _db.SSDs.Include(p => p.Manufacturer);

            ControllerActions<SSD> actions = new ControllerActions<SSD>(rams);

            rams = actions.AddFilter(manufacturer, name);

            rams = actions.AddSort(sortOrder);

            (int count, page, List<SSD> items) = actions.AddPagination(page).Result;

            ProductViewModel<SSD> viewModel = new ProductViewModel<SSD>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new SSD_FilterViewModel(await _db.SSDManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Computers(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Computer> computers = _db.Computers.Include(p => p.Manufacturer);

            ControllerActions<Computer> actions = new ControllerActions<Computer>(computers);

            computers = actions.AddFilter(manufacturer, name);

            computers = actions.AddSort(sortOrder);

            (int count, page, List<Computer> items) = actions.AddPagination(page).Result;

            ProductViewModel<Computer> viewModel = new ProductViewModel<Computer>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new Computer_FilterViewModel(await _db.ComputerManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View(viewModel);
        }
    }
}