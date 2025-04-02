## 📱**RESTful API Projesi**
RESTful API Projesi, modern ve kullanıcı dostu bir e-ticaret platformudur. Bu proje, .NET 6.0 teknolojisi kullanılarak geliştirilmiş, N-Tier (Çok Katmanlı) mimari yapısına sahip bir web uygulamasıdır.
Bu proje, bir teknoloji mağazasının kolay bir şekilde satış yapabilmesi için hazırlandı.
- 📝 Kullanıcılar ürün detaylarına bakabilir.
- 🔥 Popüler ürünlere, anasayfada bakarak hızlı karar verebilir
- ✉️ Müşteriler 'İletişim' sayfasından mağaza ile iletişime geçebilir.
- 🎨 Admin, Anasayfa da göze çarpıcı arkaplan görselleri ile müşteriyi etkileyebilir.
- 🛠️ Kolayca ürün ekleme, silme ve güncelleme işlemleri yapılabilir.

## ⚙️ **Kullanılan Teknolojiler**

- 💻 Web uygulaması yapısı için **ASP.NET Core 6.0**
- 🛠️ ORM (Object-Relational Mapping) aracı olarak **Entity Framework Core**
- 📄 Proje karmaşıklığını önlemek için **N Katmanlı Mimari**
- 🌍 RESTful API desteği ile veri alışverişi
- 📜 API dokümantasyonu için Swagger (Swashbuckle)
- ⚙️ **CRUD** işlemleri (Ekle, Listele, Güncelle, Sil)
- 📦 Veri erişim katmanını yönetmek ve uygulamanın esnekliğini artırmak için **Repository Design Pattern**
- 🗄️ Veritabanı olarak **MSSQL Server**
- 🏗️ Veritabanı modellemesi için **Code First** yaklaşımı
- 🔎 Verileri etkin bir şekilde sorgulamak için **LINQ**
- 🎨 Responsive tasarım için **HTML/CSS** ve **Bootstrap**
- 📑 Verileri sayfalara bölünerek listelenmesi için **Pagination**
  


# Proje Yapısı

Bu proje, **6 katmanlı mimari** ile yapılandırılmıştır. Her katman, ilgili işlevleri yerine getiren klasör ve dosyaları içerir.

## Proje Katmanları

| Katman Adı                      | Açıklama                       | İçindeki Klasörler / Dosyalar             |
|---------------------------------|--------------------------------|------------------------------------------|
| **CozaStore.EntityLayer**       | Veritabanı tablolarının karşılığı olan entity sınıflarını içerir. | `Concrete(Entity sınıfları)`  |
| **CozaStore.DataAccessLayer**   | Veritabanı işlemleri için Entity Framework Core implementasyonlarını içerir. | `Abstract`, `Context`, `EntityFramework`, `Migrations`, `Repositories` |
| **CozaStore.BusinessLayer**     | İş mantığı servislerini ve validasyonları içerir. | `Abstract`, `Concrete` |
| **CozaStore.DtoLayer**          | Veri transfer nesnelerini içerir. | `AboutDtos`, `CategoryDtos`, `ContactDtos`, `FeatureDtos`, `MessageDtos`, `ProductDtos` |
| **CozaStore.WebUI**             | MVC yapısında web arayüzünü içerir. | `Areas`, `Controllers`, `Models`, `Views`, `ViewComponents`, `wwwroot`, `Dtos`, `appsettings.json`, `Program.cs` |
| **CozaStore.WebAPI**            | RESTful API endpoints'lerini içerir. | `Controllers`, `appsettings.json`, `Program.cs` |

![Image](https://github.com/user-attachments/assets/6a326a6b-2928-4cf1-a8d8-d7374cbaa59e)
![Image](https://github.com/user-attachments/assets/04f244f4-fb58-4212-aad4-b58e3bea7906)
![Image](https://github.com/user-attachments/assets/e00b65e1-3939-479d-a814-4a1c65930c08)
![Image](https://github.com/user-attachments/assets/2559abdb-9432-41b1-8657-fcea1e81bfd0)
![Image](https://github.com/user-attachments/assets/71439a05-5de8-48bb-901b-67eaeb67c74c)
![Image](https://github.com/user-attachments/assets/4d636f44-34de-4995-93fd-a1ca2c617c87)
![Image](https://github.com/user-attachments/assets/a97905cf-64ab-444c-97e4-aed7eae5a1c1)
![Image](https://github.com/user-attachments/assets/03145139-9caa-450c-8b2c-27f0dd6c2f17)
![Image](https://github.com/user-attachments/assets/51b8dee5-84ed-4509-853c-8105d768b107)
![Image](https://github.com/user-attachments/assets/176abba4-e580-4359-93b7-3795b18ffc8e)
![Image](https://github.com/user-attachments/assets/ee6851a8-9f86-48eb-a4a1-9db3772b52d9)
![Image](https://github.com/user-attachments/assets/88df531d-6158-496e-836e-82d48fdb6b30)
![Image](https://github.com/user-attachments/assets/e270ebab-b362-4416-8c69-c6b838164b21)
![Image](https://github.com/user-attachments/assets/d116ebb8-1f66-48e5-b126-ff33cce1d70d)
![Image](https://github.com/user-attachments/assets/34454218-1c65-4f9a-8c10-7088c55e190e)
![Image](https://github.com/user-attachments/assets/376063b3-7299-474c-b4b7-14709d31caad)
![Image](https://github.com/user-attachments/assets/4f0226ae-032d-4160-935d-f0a9a6b94830)
![Image](https://github.com/user-attachments/assets/9d17948e-8988-464f-b02b-1636c05b0199)
