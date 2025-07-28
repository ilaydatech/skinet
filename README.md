🛍️ SkiNet E-commerce App (.NET Core & Angular)

Bu proje, Udemy'deki "Learn to build an e-commerce app with .NET Core and Angular" kursunun uygulanmasıdır. 

2. Kısmı Tamamladım:

🚀 Tamamlanan Bölüm

  - API Basics
  - CRUD işlemleri (Create, Read, Update, Delete) için Products endpoint'leri
  - Docker üzerinde SQL Server kurulumu ve konfigürasyonu
  - Postman üzerinden test senaryoları

⚙️ Kullanılan Teknolojiler

- .NET Core
- Entity Framework Core
- SQL Server (Docker container)
- Postman (API testleri için)
- Docker Desktop
- Visual Studio Code

🗄️ Veritabanı

- SQL Server Docker container kullanılarak kuruldu.
- Migration işlemleri tamamlandı.
- `skinet` isimli veritabanı oluşturuldu ve bağlandı.

💻 API Test

Postman kullanılarak ürün ekleme, listeleme, güncelleme ve silme işlemleri test edilmiştir.


Docker SQL Server Container

<img width="1778" height="968" alt="image" src="https://github.com/user-attachments/assets/b7ea743a-77eb-4671-99e0-e613f33f450b" />

Postman API Test

<img width="1752" height="828" alt="image" src="https://github.com/user-attachments/assets/76f8dbf7-7b4c-43fe-b85c-6e591e49e328" />

3. Kısmı Tamamladım:
   
Repository pattern yapısı kuruldu ve uygulandı.

Repository interface ve implementasyon class'ları oluşturuldu.

Repository method'ları yazıldı.

Controller'da repository kullanımı sağlandı.

Veritabanı için örnek (seed) ürün verileri eklendi.

Marka ve ürün tiplerini çekme endpoint'leri geliştirildi.

Ürünler için markaya göre filtreleme özelliği eklendi.

Ürünleri sıralama (sorting) özelliği eklendi.

⚙️ Yeni Eklenen Özellikler

Marka ve tip bilgilerini listeleme.

Ürünlerde sıralama ve filtreleme desteği.

Daha düzenli ve ölçeklenebilir veri erişim katmanı.

4. Kısım Tamamladım:
Bu bölümde generic repository yapısı kurularak controller içinde esnek kullanım sağlandı. Ardından specification pattern uygulanarak filtreleme, sıralama ve veri projeksiyonu gibi gelişmiş sorgu işlemleri tanımlandı. DTO kullanımıyla yalnızca ihtiyaç duyulan veriler döndürülerek veri şekillendirme yapıldı. Tüm adımlar debugger yardımıyla test edilip doğrulandı.

<img width="1747" height="881" alt="image" src="https://github.com/user-attachments/assets/fcde3ebb-31d3-4ad3-ac3f-b755146b4bbe" />

<img width="1764" height="891" alt="image" src="https://github.com/user-attachments/assets/6b8e2c5f-ffc8-4d34-a2a9-09b5e7c2781d" />
5. Kısım Tamamladım: Sorting, Filtering, Searching & Pagination
Bu bölümde ürün listeleme API’sine gelişmiş filtreleme ve sayfalama özellikleri eklendi:

ProductSpecParams sınıfı oluşturularak URL üzerinden filtre, sıralama, sayfa boyutu ve arama gibi parametreler alındı.

ProductSpecification sınıfında:

Marka ve tür filtreleme özellikleri eklendi.

Sort parametresi ile fiyat veya isim bazlı sıralama sağlandı.

ApplyPaging yöntemi ile dinamik sayfalama uygulandı.

Pagination<T> sınıfı ile toplam veri sayısı, sayfa bilgileri ve veri listesi taşındı.

BaseApiController sınıfına CreatePagedResult isimli yardımcı bir method eklendi.

ProductsController, BaseApiController'dan türetilerek ortak sayfalama kodları merkezi hale getirildi.

Son olarak Search parametresi eklenerek ürün adına göre arama yapılması sağlandı (Name.Contains(search)).

📁 İlgili dosyalar:

ProductSpecParams.cs

ProductSpecification.cs

Pagination.cs

BaseApiController.cs

ProductsController.cs

6. Kısmı Tamamladım: Erros Handling on the API
Bu bölümde, API'mize özel hata yönetimi (custom error handling) ve CORS (Cross-Origin Resource Sharing) desteği eklendi. Amaç, API'nin hem daha güvenli hem de kullanıcı dostu hale gelmesini sağlamak.

✅ Yapılanlar
📍 BuggyController ile Hata Senaryoları Testi
BuggyController.cs dosyası eklendi.

Bu controller aracılığıyla farklı HTTP hata türlerini simüle eden endpoint'ler oluşturuldu:

401 Unauthorized

400 Bad Request

404 Not Found

500 Internal Server Error

400 Validation Error (Model doğrulama)

📍 CreateProductDto ile Model Doğrulama (Validation)
CreateProductDto.cs sınıfı oluşturularak frontend'den gelen ürün verileri için doğrulama kuralları tanımlandı.

[Required], [Range] gibi veri anotasyonları kullanıldı.

Validation hataları, otomatik olarak 400 yanıtı döndürür.

📍 ApiErrorResponse ile Standart Hata Yapısı
ApiErrorResponse.cs sınıfı tanımlanarak hata durumlarında dönecek JSON yapısı belirlendi.

Geliştirici ortamında detaylı (stack trace dahil), üretim ortamında sade hata mesajı döner.

📍 ExceptionMiddleware ile Global Hata Yönetimi
Tüm uygulamayı kapsayan özel bir middleware (ExceptionMiddleware.cs) tanımlandı.

try-catch blokları yerine tüm hataları burada yakalayıp yapılandırılmış JSON olarak kullanıcıya iletir.

📍 CORS Yapılandırması
Program.cs dosyasında:

AddCors() metodu ile servis olarak eklendi.

UseCors() ile http://localhost:4200 ve https://localhost:4200 domainlerinden gelen isteklere izin verildi.

Bu sayede frontend (Angular) uygulamaları bu API’ye sorunsuz şekilde bağlanabilir.

📍 Middleware Entegrasyonu
UseMiddleware<ExceptionMiddleware>() komutu ile özel hata yönetimi uygulama pipeline’ına dahil edildi.

7. Kısımı Tamamladım:
Angular, Angular Material ve Tailwind kurulumu yapıldı.

8. Kısmı Tamamladım:
   
   <img width="1904" height="898" alt="image" src="https://github.com/user-attachments/assets/a93a639b-f38e-4a94-8493-c181b529026c" />

HttpClient ile API Entegrasyonu, Observable Yönetimi ve TypeScript Tip Modelleme

Bu bölümde Angular uygulaması ile .NET Core API arasında başarılı bir veri iletişimi kurulmuştur. Angular'ın `HttpClientModule` modülü projeye dahil edilmiş, `ShopComponent` içerisinde `HttpClient` servisi kullanılarak `GET` isteği ile ürün verileri backend’den alınmıştır.

Backend tarafında `https://localhost:5001/api/products` endpoint’ine yapılan bu istek, Angular içerisinde `this.http.get<Pagination<Product>>(...)` şeklinde yapılandırılmış ve dönen veri `Observable` yapısı ile karşılanmıştır. `subscribe()` fonksiyonu aracılığıyla veri akışı dinlenmiş, başarılı yanıt geldiğinde `products` değişkenine atanarak şablon tarafında görüntülenmesi sağlanmıştır.

Bu süreçte Observable mantığı detaylı biçimde öğrenilmiş; veri akışlarının nasıl çalıştığı, ne zaman tetiklendikleri ve `subscribe()` ile nasıl veri alınabildiği incelenmiştir. Ayrıca RxJS kütüphanesinin temel özellikleri (stream yapısı, iptal edilebilirlik, pipe operatörleri gibi) örneklerle anlaşılmıştır.

Bölümde ayrıca TypeScript dilinin güçlü tip sistemi kullanılarak `type Todo`, `type Pagination<T>` gibi özel ve generic veri modelleri tanımlanmıştır. Bu sayede hem yeniden kullanılabilir hem de güçlü şekilde tip denetimi yapan veri yapıları oluşturulmuştur. API'den dönen verilerin tip güvenliği sağlanarak daha sağlam ve hatasız bir Angular uygulamasının temeli atılmıştır.


📂 Çalıştırma

```bash
# API'yi başlat
dotnet run
