# 012 ARRAY ASENDING SORT

## Tóm tắt 
- Sắp xếp mảng tăng dần bằng `Array.Sort()` và giảm dần `Array.Reverse`. **Sử trực tiếp trên mảng ban đầu**. 

- Thuật toán **Bubble Sort**

- Đổi chỗ 2 phần tử (bằng biến tạm). **Lý do**?
```txt
Giả sử:
A = 5
B = 8

Nếu viết
A = B;
B = A;

Ta có, KQ như sau: 
A = 8
B = 8
Giá trị 5 đã mất.

=> Cần biến trung gian temp để giữ giá trị cũ.
```

- Phương thức `PrintArray` để in mảng gọn hơn

## Thuật toán
- Cách 1 - `Array.Sort`: sắp xếp tăng dần chỉ trong 1 dòng. Ngược lại, ta có `Array.Reverse`. 

 >    `Array.Sort(numbers)` sửa trực tiếp mảng gốc (không trả về mảng mới). Sau lệnh này, numbers đã được sắp xếp. **Cách này tương đối nhanh, dễ học**

- Cách 2 - `Bubble Sort`: quá trình tự lặp đi lặp lại, từng cặp liền kề, nếu sai thứ tự thì đổi. Nếu *mảng nhiều giá trị* => cập so sánh lớn --> tốc độ xử lí *chậm*

>      Muốn hoán đổi hai số, cần một số trung gian (số thứ 3) `temp`. 
>      Nếu gán thẳng `arr[j] = arr[j + 1]` mà không có `temp` thì giá trị cũ bị ghi đè. Dĩ nhiên, khi đó kết quả in ra không đúng. 

- Cách 3 - `Selection Sort`: sắp xếp có chọn lọc, mỗi lượt tìm phần tử nhỏ nhất rồi đưa lên đầu 

## Lỗi "vô tri" đã phát giác
### Lỗi 1
- Quên gọi
 `Array.Sort(numbers);`
=> Mảng không thay đổi.
---

### Lỗi 2 
- Lỗi `IndexOutOfRangeException` khi viết khối lệnh **Bubble Sort**
    - Nguyên nhân **j chạy tới n-1**
    - Code ban đầu: `arr[j+1] => arr[n]`
- Sửa thành `j < n-i-1` 

---
> > ⚠️ **Cảnh báo** @@
>
> File `Program.cs` hiện tại khá dài và RẤT VÔ TRI.
>
> *Lý do*:
> - Tác giả đang học cách viết từng thuật toán.
> - Muốn nhìn chúng cạnh nhau để dễ so sánh.
> - Chưa tới giai đoạn "dọn nhà".
