# Architectural & Design Critique: C++ Procedural Order System

## Overview
The provided C++ implementation manages `Customers`, `Products`, `Orders`, and `OrderLines` using a purely procedural approach without leveraging structures (`struct`) or classes (`class`). While the code executes correctly for small-scale demonstration scenarios, it possesses critical architectural flaws regarding data integrity, maintainability, scalability, and security.

---

## Key Design Issues Identified

### 1. Global State Management & Scatter (Global Variables)
* **Problem:** المشكلة هنا في ال Global variables.
* why ? 1- اي فانكشن تقدر تعدي تغيير القيم ومش اي فانكشن بس كمان ده حرفيا اي حد معدي 
        2- كمان لو حصل اي مشكلة وانت مش عارف المشكلة ديه بسبب مين ولا فين 
        3- لو غيرت قيمة في حته واحدة بس هتتغير في كله وممكن مبقاش عايز ده



### 2. Parallel Arrays (Lack of Encapsulation)
* **Problem:** عندك اراي ل كل عنصر فعال في البرنامج فا بالتالي لو حصل اي مشكلة في الانديكس البيانات كلها هتدخل في بعضها وهتضيع 


### 3. Hardcoded Fixed Capacities
* **Problem:** دلوقتي الحجم الثابت ده ممكن يعمل مشكلة وهي لو العدد قليل اهدرت مساحة كبيرة  من الميموري طيب لو العدد زاد مش هتعرف تضيف خلاص 


### 4. Weak Data Integrity         
* **Problem:** عدم وجود access modifiers هيؤدي ان اي حد ممكن يشوف كل حاجه عندي مفيش حماية وكمان اي حد ممكن يدخل اي حاجه بقي بالسالب مفيش validation 


