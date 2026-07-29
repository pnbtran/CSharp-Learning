# 015 ĐẢO PHẦN TỬ CỦA MẢNG
## Tóm tắt
- Kỹ thuật 2 con trỏ (two pointers).

Kỹ thuật 2 con trỏ (two pointers).
>  Vòng lặp dừng khi batDau >= ketThuc (hai con trỏ gặp nhau hoặc vượt nhau) - tức đã đảo xong nửa mảng (mỗi cặp đổi một lần là đủ). Đảo “tại chỗ” nên không tốn mảng mới -> tiết kiệm bộ nhớ. 

   {10, 20, 30, 40, 50}
    ^                ^      đổi 10<->50 -> {50,20,30,40,10}
        ^        ^          đổi 20<->40 -> {50,40,30,20,10}
            ^                hai con trỏ gặp nhau ở 30 -> **DỪNG**

- Phương thức có sẳn `Array.Reverse()`.