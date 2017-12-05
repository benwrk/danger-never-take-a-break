﻿using System.Collections.Generic;

public class Question
{
    public static readonly List<Question> QuestionList1 = new List<Question>
    {
        new Question(1, "ขอบฟุตบาทสี ขาวสลับแดง ดังภาพ ข้อใดถูกต้องที่สุด", 0, "ห้ามหยุดห้ามจอด",
            "หยุดจอดรับส่งผู้โดยสารได้ชั่วขณะ", "จอดได้ถ้าสนิทกับจราจร", "ห้ามจอดแช่"),
        new Question(2, "ภาพป้ายจราจรนี้ หมายความว่า", 0, "ห้ามหยุดรถ", "ห้ามเข้า", "ห้ามผ่าน", "ห้ามจอดรถ"),
        new Question(3, "ภาพป้ายจราจรนี้ หมายความว่า", 1, "ทางข้ามข้างหน้า", "ข้างหน้า โรงเรียน ระวังเด็ก",
            "เขตปลอดภัย", "ผิดทุกข้อ"),
        new Question(4, "ภาพป้ายจราจรนี้ หมายความว่า", 3, "ข้างหน้าเป็นทางเบี่ยง", "เข้าเขตถนนมีรั้วกัน",
            "ทางข้างรถไฟ แบบไม่มีเครื่องกั้น", "ทางข้ามรถไฟแบบมีเครื่องกั้น"),
        new Question(5, "ภาพป้ายจราจรนี้ หมายความว่า", 1, "ห้ามรถเก๋ง", "ห้ามรถยนต์", "รถเก๋งผ่านได้", "รถยนต์ผ่านได้"),
        new Question(6, "ภาพป้ายจราจรนี้ หมายความว่า", 2, "ห้ามรถบรรทุกน้ำหนักเกิน 50 ตัน",
            "ให้ขับรถ ด้วยความเร็วไม่ต่ำกว่า 50", " ห้ามขับรถเร็วเกิน 50", "ห้ามรถบรรทุกสูงเกิน 5 เมตร"),
        new Question(7, "ภาพป้ายจราจรนี้ หมายความว่า", 1, "ห้ามหยุดรถ", "ห้ามเข้า", "ห้ามผ่าน", "ห้ามจอดรถ"),
        new Question(8, "ภาพป้ายจราจรนี้ หมายความว่า", 0, "ให้รถสวนทางมาก่อน", "ห้ามแซง", "ให้รถสวนทางหยุดรถ",
            "สวนทางกันได้แต่ต้องระวัง"),
        new Question(9, "ภาพป้ายจราจรนี้ หมายความว่า", 1, "ห้ามออกขวา", "ห้ามแซง", "แซงทางขวา", "ห้ามเร่งความเร็ว"),
        new Question(10, "ภาพป้ายจราจรนี้ หมายความว่า", 1, "เขตห้ามแซง", "เตือนรถกระโดด", "ทางร่วน",
            "ถนนข้างหน้าทางขรุขระ"),
        new Question(11, "ภาพป้ายจราจรนี้ หมายความว่า", 0, "ห้ามรถสูงเกินกำหนด", "ห้ามรถกว้างเกินกำหนด",
            "ห้ามรถหนักเกินกำหนด", "จำกัดความเร็ว"),
        new Question(12, "แจ้งใบขับขี่หาย หรือชำรุดภายในกี่วัน", 1, "7 วัน", "15 วัน", "30 วัน", "60 วัน"),
        new Question(13, "ต่อใบขับขี่ล่วงหน้า ได้กี่เดือน (รถส่วนบุคคล - 5 ปี)", 2, "1 เดือน", "2 เดือน", "3 เดือน",
            "4 เดือน"),
        new Question(14, "รถยนต์ที่มีอายุครบกี่ปี ต้องตรวจสภาพก่อนเสียภาษี", 1, "6 ปี", "7 ปี", "8 ปี", "9 ปี"),
        new Question(15, "ตาม พ.ร.บ.รถยนต์ พ.ศ. 2522 รถยนต์ หมายความว่า", 3,
            "รถสาธารณะ รถยนต์บริการ รถยนต์ส่วนบุคคล รถแท็กซี่", "รถสาธารณะ รถยนต์บริการ และรถจักรยานยนต์ส่วนบุคคล",
            "รถจักรยานยนต์สาธารณะ รถบริการ และรถจักรยานยนต์", "รถสาธารณะ รถยนต์บริการ และรถยนต์ส่วนบุคคล")
    };

    public static readonly List<Question> QuestionList2 = new List<Question>
    {
        new Question(16, "ใบอนุญาตขับรถชนิดชั่วคราวมีอายุกี่ปี", 1, "1 ปี", "2 ปี", "3 ปี", "4 ปี"),
        new Question(17, "ทัศนคติและจิตสำนึก ในการขับรถอย่างปลอดภัย ของผู้ขับรถคืออะไร", 2, "ขับรถช้า ใจเย็น",
            "ขับรถเก่งคล่องแคล่ว", "ขับรถอย่างมีสติ เคร่งครัดวินัยจราจร แสดงออกถึงมารยาทและน้ำใจ",
            "ขับรถดีไม่เกิดอุบัติเหตุ"),
        new Question(17, "หากมีผู้ขับรถกำลังกลับรถเข้ามาในช่องทางที่ท่านขับรถอยู่ ท่านจะตัดสินใจทำอย่างไร", 0,
            "มีใจกรุณาโอบอ้อมอารี ให้ทางแก่ผู้กลับรถ", "หงุดหงิด บีบแตรไล่ แต่หยุดรถให้",
            "เร่งความเร็ว เพื่อขอทางไม่ให้กลับรถ", "หลบรถโดยแซงไปอีกช่องทางหนึ่ง"),
        new Question(19, "ข้อใดเป็นปัจจัยสำคัญ ที่ก่อให้เกิดอุบัติเหตุทางถนนมากที่สุด", 1, "ถนน", "ผู้ขับขี่รถ",
            "สัญญาณไฟจราจร", "ไฟส่องถนน บริเวณทางร่วมทางแยก"),
        new Question(20,
            "สาเหตุสำคัญ ที่ทำให้การขับรถในเวลากลางคืน มีความเสี่ยงต่อการเกิดอุบัติเหตุ สูงกว่าในเวลากลางวัน คือข้อใด",
            0,
            "ทัศนวิสัยในการมองเห็น", "สภาพร่างกายของผู้ขับขี่ และสภาพรถไม่พร้อม", "คนขับหลับในเนื่องจากเมื่อยล้า",
            "ขับรถในขณะมึนเมา"),
        new Question(21, "สาเหตุของการเกิดอุบัติเหตุ", 3, "คน", "คน รถ", "คน รถ ถนน", "คน รถ ถนน สิ่งแวดล้อม"),
        new Question(22, "ข้อใดเป็นพฤติกรรมการขับขี่ที่ไม่ควรกระทำ", 0, "ขับช้าชิดขวา", "ขับเร็วชิดขวา",
            "ขับช้าชิดซ้าย", "ถูกทุกข้อ"),
        new Question(23, "ถ้าไม่มีทางเท้า ควรเดินทางตามถนนอย่างไร", 0, "เดินชิดขวา", "เดินชิดซ้าย", "เดินกลางถนน",
            "เดินตามใจชอบ"),
        new Question(24, "ขับรถแต่ใช้ ใบขับขี่หมดอายุ ปรับเท่าไหร่", 1, "ปรับไม่เกิน 1 พันบาท", "ปรับไม่เกิน 2 พันบาท",
            "ปรับไม่เกิน 3 พันบาท", "ปรับไม่เกิน 5 พันบาท"),
        new Question(25, "ประเทศไทยกำหนดให้ทศวรรษแห่งความปลอดภัยทางถนนเริ่มต้นปีใด และสิ้นสุดปีใด", 1,
            "พ.ศ. 2553 - 2562", "พ.ศ. 2554 - 2563", "พ.ศ. 2552 - 2561", "พ.ศ. 2555 – 2564"),
        new Question(26,
            "พ.ร.บ. จราจรทางบก พ.ศ. 2522 กำหนดปริมาณแอลกอฮอล์ในเลือด สำหรับผู้ขับขี่ที่มีอายุไม่ถึง 20 ปีบริบูรณ์ให้ถือว่าเมาสุราที่ปริมาณเท่าใด",
            0, "20 มิลลิกรัม%", "30 มิลลิกรัม%", "40 มิลลิกรัม%", "50 มิลลิกรัม%"),
        new Question(27, "พฤติกรรมของผู้ขับขี่ข้อใด ที่เป็นสาเหตุการเกิดอุบัติเหตุทางถนน", 3, "เมาสุรา", "ขับรถเร็ว",
            "ตัดหน้ากระชั้นชิด", "ถูกทุกข้อ"),
        new Question(28, "หมายเลขสายด่านกรณีเจ็บป่วยฉุกเฉิน หรืออุบัติเหตุคือหมายเลขใด", 0, "1669", "1199", "1111",
            "1784"),
        new Question(29,
            "ผลการศึกษาวิจัยเปรียบเทียบการขับรถเร็ว แล้วชนกับการตกจากที่สูง ถ้าขับเร็ว 120 กม./ชม. เทียบได้กับการตกตึกกี่ชั้น",
            2, "4 ชั้น", "12 ชั้น", "19 ชั้น", "25 ชั้น"),
        new Question(30, "สถานการณ์ใดใช้ไฟฉุกเฉินได้อย่างเหมาะสม", 3, "เปิดไฟฉุกเฉินในขณะที่หมอกลงจัด",
            "เปิดไฟฉุกเฉิน เมื่อกำลังจะเลี้ยวซ้าย บริเวณทางแยกที่ไม่มีสัญญาณไฟจราจร",
            "เปิดไฟฉุกเฉิน เพื่อให้ผู้ขับขี่ท่านอื่นทราบว่าตนจะวิ่งตรงไป",
            "เปิดไฟฉุกเฉิน เมื่อรถจอดเสียอยู่บริเวณไหล่ทาง")
    };

    public readonly string[] Choices;
    public readonly int CorrectChoiceIndex;
    public readonly int QuestionNumber;
    public readonly string Text;

    private Question(int questionNumber, string text, int correctChoiceIndex, params string[] choices)
    {
        QuestionNumber = questionNumber;
        Text = text;
        CorrectChoiceIndex = correctChoiceIndex;
        Choices = choices;
    }
}