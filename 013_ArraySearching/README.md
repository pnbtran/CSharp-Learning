# 013 TÌM KIẾM PHẦN TỬ

## Tóm tắt
1. **Tìm kiếm tuyến tính (Linear Search)**: dò từng phần đầu đến cuối mảng, gặp đúng thì trả vị trí, hết mảng mà không tìm ra thì trả `-1`. 
- Ưu điểm: đơn giản, dễ hiểu và không cần sắp xếp.
- Nhược điểm: chậm với mảng lớn và xấu nhất khi phải duyệt cả mạng với độ phức tạp O(n)
> **Lưu ý**: Quy ước kết quả trả về `-1` khi không tìm thấy kết quả vì: `-1` không bao giờ là chỉ số hợp lệ (chỉ số luôn >=0) 
2. **Tìm kiếm nhị phân (Binary Search)**: so sánh với phần tử ở giữa, bỏ nữa không chứa kết quả, thữ hiện chia đôi đến khi tìm ra kết quả. 

## Lưu ý
- Tìm tuyến tính - do từng phần tử (chậm, không cần sắp xếp).
- Tìm nhị phân - chia đôi liên tục (nhanh, nhưng cần sắp xếp).
- Thực tế: `Array.BinarySearch` (đã sắp xếp) hoặc `Array.IndexOf` (tuyến tính). Mẹo nhớ: tuyến tính dò từng cái `(O(n))`; nhị phân chia đôi `(O(log n)`, cần đã sắp xếp. `-1` = không thấy.

- *Tại sao không dùng* `(left + right) / 2 ?`
    - Vì khi left và right rất lớn, phép cộng có thể vượt quá giới hạn của kiểu int (overflow).
    - Do đó nên dùng: `left + (right - left) / 2` để đảm bảo an toàn.

## Lỗi "vô tri" đã phát giác
1. Viết sai cú pháp hàm 

- Sai: `int[] arr = (1,2,3,4);`

- Đúng: `int[] arr = { 1,2,3,4 };`

2. Lỗi trả kết quả khi tìm kiếm nhị phân

- Sai: 
```csharp
if(arr[mid] < target)
    return mid + 1;
```

- Đúng: 
```csharp
if(arr[mid] < target)
    left = mid + 1;
```
- Lí do: 
    - Tìm nhị phân chưa xong
    - Phải thu hẹp phạm vi

- Bài học: Tìm kiếm nhị phân chỉ `return` khi
    - Tìm thấy
    - Hoặc không còn cùng tìm kiếm