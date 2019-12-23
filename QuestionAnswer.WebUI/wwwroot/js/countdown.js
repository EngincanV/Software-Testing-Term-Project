$(document).ready(function () {
    $("#instantQuestion").text(1);
    var questionNo = 1;

    var minuteCounter = 60;
    var secondCounter = 0;
    var minute = $("#minute");
    var seconds = $("#seconds");

    minute.text(minuteCounter);
    seconds.text("0" + secondCounter);

    setInterval(function () {
        setTimeout(function () {
            if (secondCounter === 0) {
                minuteCounter--;
                secondCounter = 60;
            }
            secondCounter--;
            secondCounter >= 0 && secondCounter <= 9
                ? (seconds.text("0" + secondCounter))
                : (seconds.text(secondCounter));

            minuteCounter >= 0 && minuteCounter <= 9
                ? (minute.text("0" + minuteCounter))
                : (minute.text(minuteCounter));

            if (secondCounter === 0 && minuteCounter === 0) {
                clearTimeout();
                clearInterval();
                window.location.href = "/Test/ExamResult";

            }
        }, 1000);
    }, 1000);

    var tempAnswer = "";
    $("#first").click(function () { tempAnswer = $("#firstContent").val() });
    $("#second").click(function () { tempAnswer = $("#secondContent").val() });
    $("#third").click(function () { tempAnswer = $("#thirdContent").val() });
    $("#fourth").click(function () { tempAnswer = $("#fourthContent").val() });

    $("#submittedForm").click(function () {
        questionNo++;

        var id = $("#questionId").text();
        $("#studentAnswer").val(tempAnswer);
        console.log(id);

        var studentAnswer = $("#studentAnswer").val();
        console.log(studentAnswer);

        var jsonData = JSON.stringify({
            AnswerContent: studentAnswer,
            QuestionId: id
        });
        console.log(jsonData);

        $.ajax({
            type: "POST",
            url: "/Test/Exam",
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: jsonData,
            success: function (data) {
                if (data == "testResult") {
                    window.location.href = "/Test/ExamResult";
                }
                else if (data !== "") {
                    $("#first").text("A) " + data.firstContent);
                    $("#firstContent").val(data.firstContent);

                    $("#second").text("B) " + data.secondContent);
                    $("#secondContent").val(data.secondContent);

                    $("#third").text("C) " + data.thirdContent);
                    $("#thirdContent").val(data.thirdContent);

                    $("#fourth").text("D) " + data.fourthContent);
                    $("#fourthContent").val(data.fourthContent);

                    $("#questionId").text(data.id);
                    $("#questionImg").attr("src", data.questionImage);

                    $("#instantQuestion").text(questionNo);
                }
                else
                    window.location.reload();
            }
        });
    });
});