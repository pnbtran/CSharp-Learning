# 008 ĐẾM SỐ NGUYÊN TỐ 

## Mô tả
*Chương trình*
- Nhập hai số nguyên.
- Liệt kê các số nguyên tố trong khoảng.
- Đếm số lượng số nguyên tố.

*Lưu ý*
- Xử lý trường hợp người dùng nhập ngược khoảng: \[giá trị bắt đầu] > \[giá trị kết thúc].
- Số 0 và 1 không phải là số nguyên tố.
- Số 2 là số nguyên tố chẵn duy nhất.
- Chỉ kiểm tra các ước từ 3 đến $\sqrt{n}$
  
## Thuật toán
1. Nhập: giá trị bắt đầu và giá trị kết thúc
2. Nếu giá trị bắt đầu > giá trị kết thúc thì hoán đổi giá trị
3. Duyệt từng số trong khoảng
4. Gọi hàm `SoNguyenTo` để kiểm tra
5. Nếu là số nguyên số: 
- In ra màn hình
- Tăng biến đếm
6\. Hiển thị tổng số nguyên tố 

## Ví dụ
Kiểm tra với **n = 97**
Giá trị: $\sqrt{97}$ ≈ 9 

| Số kiểm tra | Kết quả |
|------------:|:-------:|
| 3 | ✗ |
| 5 | ✗ |
| 7 | ✗ |
| 9 | ✗ |

**Kết luận:** Không tìm thấy ước số ⇒ **97 là số nguyên tố.** 

## Ghi chú
* Tại sao không kiểm tra: chia đến `n-1`, mà lại chia đến $\sqrt{n}$
Lấy ví dụ số 100, ta có các cặp ước chung như sau: 

| Ước nhỏ | × | Ước lớn | Ghi chú |
|---------:|:-:|--------:|----------|
| 1 | × | 100 | |
| 2 | × | 50 | |
| 4 | × | 25 | |
| 5 | × | 20 | |
| **10** | × | **10** | $\sqrt{100}$ |
| 20 | × | 5 | |
| 25 | × | 4 | |
| 50 | × | 2 | |
| 100 | × | 1 | |

Ta thấy:
* Các ước của một số luôn xuất hiện theo từng cặp.
* Mỗi cặp luôn có số nhở hơn hoặc bằng $\sqrt{100}$ = 10 
* Nếu tồn tại một ước lớn hơn √n thì chắc chắn sẽ tồn tại một ước nhỏ hơn hoặc bằng $\sqrt{n}$.
Do đó, chỉ cần kiểm tra các số từ 2 đến √n. Nếu không tìm thấy ước nào thì số đó là số nguyên tố.
⇒ Các ước của một số luôn xuất hiện theo cặp. Trong mỗi cặp, luôn có ít nhất một ước nhỏ hơn hoặc bằng √n. Vì vậy, chỉ cần kiểm tra các số từ 2 đến $\sqrt{n}$. Nếu không tìm thấy ước nào trong khoảng đó thì chắc chắn không tồn tại ước lớn hơn √n, và số đó là số nguyên tố.

