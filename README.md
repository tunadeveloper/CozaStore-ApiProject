## 📱**Teknoloji API Projesi**
Teknoloji API Projesi, modern ve kullanıcı dostu bir e-ticaret platformudur. Bu proje, .NET 6.0 teknolojisi kullanılarak geliştirilmiş, N-Tier (Çok Katmanlı) mimari yapısına sahip bir web uygulamasıdır.
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
