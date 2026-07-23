# 009 XỬ LÝ NGOẠI LỆ KHI CHIA CHO SỐ 0

## Nội dung 
[x] Hiểu ngoại lệ (exception) là gì và vì sao cần xử lý. 
- Ngoại lệ (Exception): sự kiện bất thường, làm gián đoạn luồng xử lí. 
- Lí do cần xử lý ngoại lệ:
    - Ngăn chương trình `crash` đột ngột.
    - Cho người dùng thông báo lỗi *thân thiện*.
    - Cho phép chương trình tiếp tục hoặc kết thúc có kiểm soát. 
    - Ghi lại lỗi để debug.

[x] Dùng `try-catch` để bắt lỗi chia cho 0 (DivideByZeroException).
[x] Bắt nhiều loại lỗi với nhiều khối catch.
[x] Dùng khối finally để dọn dẹp (luôn chạy).
[x] Phân biệt khi nào nên try-catch vs kiểm tra điều kiện trước.

- **Kết luận:**: `try { việc có thể lỗi } catch (LoạiLỗi) { xử lý } finally { luôn chạy }` - tấm lưới an toàn giúp chương trình không “đột tử”.

## Số nguyên và số thực khi chi cho 0
``````csharp
int a = 10 / 0;               // NÉM DivideByZeroException
double b = 10.0 / 0;         // KHÔNG ném lỗi! -> b = Infinity (vô cực) 
double c = 0.0 / 0.0;       // KHÔNG ném lỗi! -> c = NaN (Not a Number)
``````

- Lỗi lường trước -> kiểm tra if; lỗi bất ngờ -> try-catch.
- Bài học: với **số nguyên** chia 0, ngoại lệ giúp bạn phát hiện ngay. Nhưng với **số thực**, kết quả là `Infinity/NaN` âm thầm - không lỗi nhưng tính toán về sau sẽ “loạn”. Vì vậy, nhiều khi kiểm tra điều kiện trước `(if (mauSo != 0))` còn tốt hơn là chỉ trông chờ `try-catch`. Dùng đúng công cụ cho đúng tình huống.

- Quy tắc thực dụng: lỗi lường trước được (chia 0, nhập rỗng) -> nên kiểm tra if trước. Lỗi bất ngờ/ngoài tầm (file biến mất, mạng rớt) -> dùng `try-catch`. 

- **Đặc biệt quan trọng**: **Đừng dùng `try-catch` để che giấu code cẩu thả!!!**

## Tóm tắt
``````csharp
   try {
       // code có thể lỗi
   }
   catch (DivideByZeroException) { ... }  // cụ thể
   catch (FormatException)        { ... }  // cụ thể
   catch (Exception ex)           { ... }  // CHUNG - đặt cuối
   finally { /* LUÔN chạy: dọn dẹp */ }
``````
| Tên| Dùng để |
|------------:|:-------:|
| Exception | Lỗi bất thường lúc chạy, làm gián đoạn |
| try-catch| *Lưới an toàn* bắt lại lỗi, tránh làm sập chương trình|
| Nhiều catch | Mỗi dạng lỗi, một khối, cụ thể trước|
| finally | Khối lệnh luôn chạy (bất kể lỗi gì) |
| int/0 và double | Ném lỗi với In thông báo Infinity/NaN |