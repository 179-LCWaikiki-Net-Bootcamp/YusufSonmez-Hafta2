# YusufSonmez-Hafta2

Microsoft.EntityFrameworkCore ve Microsoft.EntityFrameworkCore.InMemory paketlerinin 5.0.6 versiyonları kullanılmıştır.
Map işlemlerini sağlamak için AutoMapper paketi kullanılmıştır. AutoMapper Dependency injection yöntemiyle uygulanmıştır. Bunun için AutoMapper.Microsoft.DependencyInjection paketi kullanılmıştır.

Projede Products ve Genres olmak üzere birbirine bağlı iki adet tablo kullanılmıştır. Bu tablolar içerisinde primary key foreign key ilişkisi kurulmuştur.

Projede Entity FrameworkCore InMemory Database kullanılmıştır.

Projede ORM ve DTO kullanılmıştır.

Projede Model Validation kullanılmıştır.

![GOMCAM 20220421_1354070873](https://user-images.githubusercontent.com/32747222/164443933-e812c822-7e51-4620-acfa-200fa2c8b1f5.png)
GET request ile bütün türler listelenmiştir.

![GOMCAM 20220421_1355020979](https://user-images.githubusercontent.com/32747222/164443965-3b13129a-c580-4204-aa43-b0a4a1f39aef.png)
POST request ile "Yeni Tür" adlı tür eklenmiştir.

![GOMCAM 20220421_1355170232](https://user-images.githubusercontent.com/32747222/164444048-be16d031-1ca1-4264-bbb3-f4e8adf232ef.png)
GET request ile eklenen türün id'sine göre arama yapılmıştır

![GOMCAM 20220421_1356060655](https://user-images.githubusercontent.com/32747222/164444297-dfc10f44-bcf8-47ea-97d4-a36f0253729d.png)
PUT request ile eklenen tür başlığı "Eski Tür" şeklinde düzenlenmiştir

![GOMCAM 20220421_1356260258](https://user-images.githubusercontent.com/32747222/164444342-2f85c620-e739-4d04-8fac-39df35c4882e.png)
GET request ile "Eski Tür" adlı türün başlığına göre arama yapılmıştır.

![GOMCAM 20220421_1356500943](https://user-images.githubusercontent.com/32747222/164444453-ce040b10-a0fd-4719-ab89-a2b041240850.png)
Delete request işleminden sonra GET request ile "Eski Tür" adlı türün başlığına göre arama yapılmış ve ürünün silindiği görülmüştür.

![GOMCAM 20220421_1357070679](https://user-images.githubusercontent.com/32747222/164444580-43a9f96f-d6a3-48dc-8c24-fa7229acefed.png)
GET request ile idye göre arama yapıldığında türün silindiği görülmüştür.

![GOMCAM 20220421_1342100289](https://user-images.githubusercontent.com/32747222/164441650-bdfb472b-6636-41c8-a85d-68bc15bbd624.png)

GET request ile bütün ürünler listelenmiştir.

![GOMCAM 20220414_0957410221](https://user-images.githubusercontent.com/32747222/163331995-a410a575-c0ab-47d8-be48-88ae8ad26573.png)

POST request ile "Çorap" adlı ürün eklenmiştir.

![GOMCAM 20220414_0959280441](https://user-images.githubusercontent.com/32747222/163332100-43bbdd0f-3b91-4b12-b12d-7c9d8afe5846.png)

GET request ile eklenen ürünün id'sine göre arama yapılmıştır.

![GOMCAM 20220414_1000010243](https://user-images.githubusercontent.com/32747222/163332206-6c102dfd-6802-407f-8468-0b504e727c96.png)

PUT request ile eklenen ürünün başlığı "Tişört" şeklinde düzenlenmiştir

![GOMCAM 20220414_1001310293](https://user-images.githubusercontent.com/32747222/163332288-fb878847-53f0-42b5-989f-cec3635b3cf6.png)

GET request ile "Tişört" adlı ürünün başlığına göre arama yapılmıştır.

![GOMCAM 20220414_1002060469](https://user-images.githubusercontent.com/32747222/163332598-046b8a39-d18d-4669-a44b-4c5ca2b7016b.png)

DELETE request ile "Tişört" adlı ürün silinmiştir.

![GOMCAM 20220414_1002280526](https://user-images.githubusercontent.com/32747222/163332671-141868c5-e59e-4fa5-ad52-d37f2232e290.png)

Delete request işleminden sonra GET request ile "Tişört" adlı ürünün başlığına göre arama yapılmış ve ürünün silindiği görülmüştür.

![GOMCAM 20220414_1002470007](https://user-images.githubusercontent.com/32747222/163332847-31903930-1a4b-40f7-b5ab-0c5cab7277d6.png)
<!--
Projede Model Validasyonlar kullanılmıştır. Bu sayede aynı ürünler tekrar tekrar eklenememektedir ve eklenen ürünlerin formatlarında kurallar bulunmaktadır.

![GOMCAM 20220414_1018320986](https://user-images.githubusercontent.com/32747222/163334176-aa13f911-0c71-4ec4-8804-5c8978f5dbc1.png)
-->
