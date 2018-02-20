$(function () {
    var hub = $.connection.Group;

    hub.client.greetings = (message) => {
        var li = $('<li/>').html(message)
        $('#messages').append(li)
    }

    $.connection.hub
        .start()
        .done(done)
        .fail(function (error) {
            console.log(error);
        });

    let toggler = function () {
        $('#subscribe').toggle();
        $('#unsubscribe').toggle();
        $('#send').toggle();
    };

    let done = function () {
        let v = $('#group').val()
        $('#subscribe').click(function () {
            $(this).toggle()
            hub.server.subscribe(v)
            $('#send').click(function () {
                hub.server.hello(v);
            });
            $('#send').toggle()
        })

        $('#unsubscribe').click(function () {
            toggler()
            hub.server.unsubscribe(v)
        })
    }
});