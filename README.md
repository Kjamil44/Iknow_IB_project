# Проектна задача по Информациска безбедност

## Систем за оцени на студенти сличен на iKnow, каде професорот користи сертификат за најава, а студент има само преглед на неговите оцени

```
Изработиле: Ќамил Какалески 195018 и Никола Анастасовски 195012
Ментор: доц. д-р Христина Михајлоска
```

Користена платформа: **Visual Studio** со. **NET MVC**.


![s1](Screenshot_1.png)


Креиравме проект template за авторизација и автентикација при што
креиравме две улоги – **професор** и **студент**.


![s2](Screenshot_2.png)


При регистрација на студентите и професорите, доколку е студент мора да
ја има наставката **@students.finki.ukim.mk** во мејлот за да биде внесен во
базата на податоци под улога студент. Доколку регистрираниот е
професор, има наставка **@finki.ukim.mk** и ја добива улогата професор во
базата на податоци.


![s3](Screenshot_3.png)


Апликацијата се поставува на **IIS сервер**.


![s4](Screenshot_4.png)


Потоа, креиравме серверски сертификат и истиот
се поставува во MMA> **Trusted Root Certificates**.

**PKI** инфрастукурата на серверскиот сертификат е
дадена на сликата:


![s5](Screenshot_5.png)


```
Сертификатите се поставуваат во IIS
серверот и потоа се подесува страната да
подржува https.
```


![s6](Screenshot_6.png)


За регистриран студент страната работи на следниот начин:
![s7](Screenshot_7.png)


Студентот има само поглед на оцените и нема пристап до ништо друго.


![s8](Screenshot_8.png)


Додека професорот има дополнителна опција за менување на оцени, но
пред тоа треба да овозможи **дво-факторска автентикација** со користење
на **Google Authenticator**.
```
Чекорите по кои го воспоставивме Google Authenticator: 
```
[Github repo на i-marasa](https://github.com/i-marasa/ASPMVC_2FAuth) 

![s9](Screenshot_9.png)


Кога професорот ќе овозвоможи 2f автентикација, му се појавува **QR Code**
кој треба да го скенира со апликацијата за телефон- **Google Auth**. При што
секој пат кога ќе се најави на сајтот ќе му биде испратен на апликацијата,
кој има **timestamp** на внесување од 20 sec.


![s10](Screenshot_10.png)


Сега професорот може да ги **менува** , **брише** или **погледне** оцените за
студентот.


![s11](Screenshot_11.png)


Како што напоненав, доколку професорот се одјави од сајтот и повторно
се најави, ќе му биде побаран **токен** (со одредено време) кој треба да го
внесе за да се автентицира.


![s12](Screenshot_12.png)


