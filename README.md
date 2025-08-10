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

6. Kısmı Tamamladım: Erros Handling on the API
Bu bölümde, API'mize özel hata yönetimi (custom error handling) ve CORS (Cross-Origin Resource Sharing) desteği eklendi. Amaç, API'nin hem daha güvenli hem de kullanıcı dostu hale gelmesini sağlamak.

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

📍 HttpClient ile API Entegrasyonu, Observable Yönetimi ve TypeScript Tip Modelleme

📍 Bu bölümde Angular uygulaması ile .NET Core API arasında başarılı bir veri iletişimi kurulmuştur. Angular'ın `HttpClientModule` modülü projeye dahil edilmiş, `ShopComponent` içerisinde `HttpClient` servisi kullanılarak `GET` isteği ile ürün verileri backend’den alınmıştır.

📍 Backend tarafında `https://localhost:5001/api/products` endpoint’ine yapılan bu istek, Angular içerisinde `this.http.get<Pagination<Product>>(...)` şeklinde yapılandırılmış ve dönen veri `Observable` yapısı ile karşılanmıştır. `subscribe()` fonksiyonu aracılığıyla veri akışı dinlenmiş, başarılı yanıt geldiğinde `products` değişkenine atanarak şablon tarafında görüntülenmesi sağlanmıştır.

📍Bu süreçte Observable mantığı detaylı biçimde öğrenilmiş; veri akışlarının nasıl çalıştığı, ne zaman tetiklendikleri ve `subscribe()` ile nasıl veri alınabildiği incelenmiştir. Ayrıca RxJS kütüphanesinin temel özellikleri (stream yapısı, iptal edilebilirlik, pipe operatörleri gibi) örneklerle anlaşılmıştır.

📍 Bölümde ayrıca TypeScript dilinin güçlü tip sistemi kullanılarak `type Todo`, `type Pagination<T>` gibi özel ve generic veri modelleri tanımlanmıştır. Bu sayede hem yeniden kullanılabilir hem de güçlü şekilde tip denetimi yapan veri yapıları oluşturulmuştur. API'den dönen verilerin tip güvenliği sağlanarak daha sağlam ve hatasız bir Angular uygulamasının temeli atılmıştır.

9. Kısmı Tamamladım:  Ürün Filtreleme, Sıralama, Sayfalama ve Arama Özellikleri
Bu bölümde kullanıcıların ürünleri daha rahat bulabilmesi için filtreleme, sıralama, sayfalama ve arama özellikleri eklendi.
<img width="1902" height="913" alt="image" src="https://github.com/user-attachments/assets/7e7bdaaa-c08e-476b-8cec-1b95bbc31805" />

📍 Filtreleme
 Marka ve Tür Seçimi: Kullanıcılar Filters butonu ile açılan pencereden marka (Brand) ve ürün tipi (Type) seçebilir.
 
<img width="1897" height="900" alt="image" src="https://github.com/user-attachments/assets/fb865504-e902-423a-8cb6-77acd9982573" />

Dinamik Listeleme: Seçilen filtrelere göre ürün listesi anında güncellenir.

📍 Sıralama
Kriter Seçimi: Sort menüsü üzerinden ürünler fiyat, alfabe vb. kriterlere göre sıralanabilir.

<img width="1898" height="906" alt="image" src="https://github.com/user-attachments/assets/ae6e6be1-4bd0-4e3b-99de-7110c92c4025" />


📍 Sayfalama (Pagination)
Sayfa Boyutu: Items per page seçeneği ile sayfa başına ürün sayısı ayarlanabilir.

📍 Sayfa Geçişi: İleri/geri butonları ile sayfalar arasında geçiş yapılabilir.

📍 Arama (Search)
📍 Arama Kutusu: Kullanıcı, arama kutusuna yazdığı kelimeye göre ürünleri filtreleyebilir.

💡 Sonuç: Bu adım ile kullanıcı deneyimi artırılmış, ürünlere erişim kolaylaştırılmış ve aradıkları ürünlere hızlıca ulaşmaları sağlanmıştır. 🚀

10. Kısmı Tamamladım: Angular Routing ve Ürün Detay Sayfası
Bu bölümde ürün detay sayfası oluşturuldu ve Angular Routing ile ürünlere özel sayfalar tasarlandı.

<img width="1915" height="908" alt="image" src="https://github.com/user-attachments/assets/00df99c9-f18d-4a66-9e2c-e762d44a6dda" />

🚏 Routing Ayarları
 Angular Routing kullanılarak /shop/:id route'u eklendi

🖱️ Ürün kartlarına tıklanınca ilgili ürünün detay sayfasına yönlendirme yapıldı

🛠️ ProductDetailsComponent
 ActivatedRoute ile URL'den ürün id parametresi alındı

ShopService üzerinden getProduct() ile API’den ürün bilgisi çekildi

🖼️ Detay sayfasında ürün adı, fiyatı, resmi ve açıklaması gösterildi

11. Kısmı Tamamladım: Hata Yönetimi ve Loading Sistemi
📍 400, 401, 404 ve 500 HTTP hatalarını yakalamak için errorInterceptor eklendi

📍 SnackbarService ile başarı/hata bildirimleri gösterimi sağlandı

📍 404 hataları için NotFoundComponent oluşturuldu (Mağazaya dön butonu ile)

📍 500 hataları için ServerErrorComponent oluşturuldu, backend hata detayları gösteriliyor

📍 API istekleri sırasında yüklenme durumunu göstermek için loadingInterceptor eklendi

📍 BusyService ile aktif API istekleri takip edilerek yüklenme durumu yönetildi

📍 API hatalarını test etmek için TestErrorComponent eklendi

📍 app.config içinde interceptors ve hata bileşenleri tanımlandı

<img width="1912" height="905" alt="image" src="https://github.com/user-attachments/assets/435d7982-5621-4d9c-a021-24581c9c307a" />

🔹 Nasıl Çalışır
API isteği başlar
→ loadingInterceptor → busyService.busy() çağrılır → Loading spinner açılır

API cevabı gelir (başarılı ya da hatalı)
→ loadingInterceptor → busyService.idle() çağrılır → Loading spinner kapanır

Hata oluşursa
errorInterceptor HTTP hata koduna göre işlem yapar:
400 → Validation hataları veya genel hata Snackbar ile gösterilir
401 → Yetkisiz erişim mesajı Snackbar ile gösterilir
404 → /not-found sayfasına yönlendirilir
500 → /server-error sayfasına yönlendirilir, hata detayları aktarılır

Hata sayfaları
NotFoundComponent → 404 hataları için
ServerErrorComponent → 500 hataları için (detaylar gösterilir)

🔹 Test Etme
TestErrorComponent üzerinden farklı hatalar test edilebilir:
500 error → /buggy/internalerror
404 error → /buggy/notfound
400 error → /buggy/badrequest
401 error → /buggy/unauthorized
400 validation error → /buggy/validationerror

12. Kısmı Tamamladım: Redis Entegrasyonu ile Sepet (Shopping Cart) Yönetimi
Bu güncelleme ile uygulamaya **Redis** entegrasyonu eklenmiştir.  
Sepet verileri Redis üzerinde tutulmakta, böylece **hızlı erişim** sağlanmakta ve **veritabanı yükü azaltılmaktadır.
# 🛒 Redis Entegrasyonu ile Sepet (Shopping Cart) Yönetimi

📌 Genel Bakış
Bu güncelleme ile uygulamaya **Redis** entegrasyonu eklendi.  
Sepet verileri Redis üzerinde tutuluyor, böylece hızlı erişim sağlanıyor ve veritabanı yükü azalıyor.

<img width="1833" height="605" alt="image" src="https://github.com/user-attachments/assets/e55fcbc8-c953-4103-b24a-d7e28251affd" />


📌 Eklenen Özellikler

1️⃣ Redis Servisi
- docker-compose.yml dosyasına **Redis** servisi eklendi

2️⃣ .NET Redis Entegrasyonu
- StackExchange.Redis NuGet paketi projeye eklendi
- IConnectionMultiplexer Program.cs üzerinden konfigüre edildi

3️⃣ Sepet (Cart) İşlemleri
- ShoppingCart ve CartItem entity’leri oluşturuldu
- CartService içerisinde:
  - SetCartAsync() → Redis üzerinde ekleme/güncelleme
  - GetCartAsync() → Redis üzerinden okuma
  - DeleteCartAsync() → Redis’ten silme
- CartController endpointleri:
  - GET /api/cart?id={cartId}
  - POST /api/cart
  - DELETE /api/cart?id={cartId}

 4️⃣ Test
- Postman ile tüm endpointler test edildi

<img width="1376" height="898" alt="image" src="https://github.com/user-attachments/assets/5188db26-5e3e-4984-9458-c5a37ef4a3f4" />

13. Kısmı Tamamladım: Sepet işlevselliği ve ürün detay entegrasyonu 🛒

🆕 Ürün ekleme/çıkarma işlevleri tamamlandı
💾 Sepet verisi backend API üzerinden persist edilecek şekilde düzenlendi
🔄 Navbar üzerinde gerçek zamanlı sepet ürün adedi güncellemesi eklendi
📄 Sepet sayfası oluşturuldu ve item bileşenleriyle dinamik listeleme sağlandı
📊 Order Summary ve Order Totals bileşenleri geliştirildi
🔧 Ürün detay sayfasından sepet güncelleme işlevi entegre edildi

## 🛒 Sepet Modülü

Sepet modülü projenin tamamında aktif hale getirildi:

<img width="1916" height="900" alt="image" src="https://github.com/user-attachments/assets/2d050f6f-6f7d-4bdd-ad13-f61715a815a0" />


- 🆕 Ürün Ekleme
   ProductItemComponent üzerinden CartService ile tetiklenir
- 💾 Veri Kalıcılığı
   Sepet verisi CartService içindeki signal ile yönetilir, backend API’ye kaydedilir
- 🔄 Gerçek Zamanlı Güncelleme
   Navbar üzerindeki itemCount computed değeri signal değiştikçe otomatik yenilenir
- 📄 Sepet Sayfası
   CartComponent, CartItemComponent ile tüm ürünleri dinamik listeler
- 📊 Sipariş Özeti
   OrderSummaryComponent ve OrderTotalsComponent; ara toplam, indirim, kargo ve toplam hesaplamalarını yapar
- ➕➖ Adet Güncelleme
   Ürün miktarı arttırma/azaltma ve silme işlemleri CartService üzerinden API ile backend’e iletilir
- 🔧 Ürün Detay Entegrasyonu
   ProductDetailsComponent üzerinden Update Cart özelliği ile quantity doğrudan güncellenebilir

<img width="1913" height="898" alt="image" src="https://github.com/user-attachments/assets/5619ad6d-144f-4904-8fbc-13c7e258c558" />

14. Kısmı Tamamladım: Identity & User Management

📍 Bu bölümde kullanıcı yönetimi ve kimlik doğrulama sistemi tamamlandı.

Identity kurulumu:
AppUser modeli oluşturuldu (FirstName, LastName alanları eklendi).
StoreContext IdentityDbContext<AppUser> olarak güncellendi.
Identity endpoint’leri (/register, /login, /logout) aktif hale getirildi.

📍 Custom Register Endpoint:
AccountController içinde kullanıcı kaydı için özel endpoint eklendi.
Postman üzerinden JSON body ile kayıt işlemleri test edildi.

📍 Authentication Testing:
Cookie tabanlı login/logout işlemleri test edildi.
[Authorize] attribute ile korumalı endpointler kontrol edildi.
Additional User Endpoints
GetUserInfo → Giriş yapmış kullanıcının bilgilerini döner.
GetAuthState → Kullanıcının oturum durumunu kontrol eder.

📍 Extension Methods:
ClaimsPrincipalExtensions ile giriş yapmış kullanıcıyı email üzerinden bulma kolaylaştırıldı.
AddressMappingExtensions ile AddressDto ↔ Address dönüşümleri eklendi.

Validation:
DTO seviyesinde validation hataları test edildi.
User Address Management
Address entity ve AddressDto eklendi.
CreateOrUpdateAddress endpoint’i ile kullanıcı adres ekleme/güncelleme işlemleri tamamlandı.

15. Kısmı Tamamladım: Kimlik Doğrulama, Validasyon ve Guard Yapısı

<img width="1899" height="907" alt="image" src="https://github.com/user-attachments/assets/f185e426-f93b-46a9-9a91-c0c6426d4a9b" />

<img width="1918" height="905" alt="image" src="https://github.com/user-attachments/assets/0ad4d503-10ed-4651-8f3a-f4be6a9e8aa2" />

<img width="1913" height="903" alt="image" src="https://github.com/user-attachments/assets/5c662279-993a-4b34-9fcc-251e46ff8dd0" />


📍 Auth Interceptor oluşturularak tüm HTTP isteklerine withCredentials desteği eklendi
📍 Angular Material Menu entegre edilerek kullanıcı menüsü oluşturuldu
📍 Register formu eklendi ve login formu ile form validasyon kuralları (zorunlu alan, e-posta formatı vb.) tamamlandı
📍 Reusable TextInput bileşeni geliştirildi (hata mesajları dinamik)
📍 Auth Guard eklendi ve Observable tabanlı kontrol ile güncellendi
📍 Empty Cart Guard oluşturularak boş sepet yönlendirmesi eklendi
📍 Empty State Component eklendi (boş veri durumları için kullanıcıya bilgi gösterimi)

Auth Interceptor: Tüm HTTP isteklerine withCredentials eklenerek cookie tabanlı login güvenliği sağlandı.
Angular Material Menü: Header üzerinde login olmuş kullanıcıya özel açılır menü eklendi.
Login & Register Formları: Reactive Forms kullanılarak form validasyonu tamamlandı (Validators.required, Validators.email vb.).
Reusable TextInput Component: Tekrarlı form alanları yerine yeniden kullanılabilir input bileşeni geliştirildi.
Auth Guard: Login gerektiren sayfalar için guard eklendi; Observable tabanlı versiyona güncellendi.
Empty Cart Guard: Sepet boşsa checkout sayfasına erişim engellenip kullanıcı bilgilendirildi.
Empty State Component: Boş veri durumlarında kullanıcıya uygun mesaj gösteren komponent eklendi.

16. Kısım Tamamlandı: Checkout & Stripe Entegrasyonu
Bu bölümde, tam bir e-ticaret ödeme akışı geliştirildi: Address → Shipping → Payment → Confirmation.
Amaç, kullanıcıdan teslimat adresini ve kargo yöntemini alarak, Stripe ile güvenli bir şekilde ödeme alıp siparişi tamamlamak. 🎯

<img width="1891" height="868" alt="image" src="https://github.com/user-attachments/assets/f981e76a-dee1-472c-be30-519af9145b72" />


🚀 Yapılanlar
📦 1. Teslimat Yöntemleri (Delivery Methods)
API’den kargo seçenekleri çekildi.
Seçilen yöntem, toplam tutara anında yansıtıldı.
Kullanıcı adım geçmeden seçim yapmak zorunda.

🏠 2. Adres Adımı (Address Step)
Stripe Address Element ile adres formu oluşturuldu.
Otomatik doldurma (ülke, il, ilçe, posta kodu).
"Save as default address" seçeneği eklendi. ✅

💳 3. Ödeme Adımı (Payment Step)
Backend’den alınan clientSecret ile Stripe Elements başlatıldı.
Payment Element eklendi, kart bilgisi güvenli şekilde alındı.
Ödeme yöntemi seçilmeden adım geçişi engellendi.

📄 4. Onay / Review Adımı
Confirmation Token oluşturuldu.
Adres, kargo ve sepet bilgileri özetlendi.
Kart bilgileri maskeleme için özel PaymentCardPipe geliştirildi:

✅ 5. Ödeme Onayı
3D Secure (SCA) gereksinimleri desteklendi.
Başarılı ödemede checkout success sayfasına yönlendirildi.

🛠 Teknik Notlar
PaymentIntent backend’de oluşturuluyor, frontend sadece clientSecret kullanıyor.
PaymentCardPipe, kart numarasını maskelerken markayı büyük harf yapıyor.
Adımlar completion status ile kontrol ediliyor (adres yoksa Payment’a geçilemiyor vb.).
redirect: 'if_required' ile 3D Secure işlemleri yönetiliyor.

✨ Sonuç
Bu geliştirme ile:
Güvenli Stripe ödemesi
Kullanıcı dostu checkout akışı
Doğrulama ve hata yönetimi
3D Secure uyumu
tamamlandı. 

⚙️ Çalıştırma Adımları
1. Docker Compose ile Redis’i başlat**
   powershell
   docker compose up -d

---

📂 Çalıştırma

```bash
# API'yi başlat
dotnet run
