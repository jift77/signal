$(function () {
    let hub = $.connection.Group;
    hub.client.greetings = (message) => {
        var li = $('<li/>').html(message)
        $('#messages').append(li)
    }

    let done = function () {
        let v = $('#group').val()

        $('#subscribe').click(function () {
            toggler()
            hub.server.subscribe(v)
        })

        $('#unsubscribe').click(function () {
            toggler()
            hub.server.unsuscribe(v)
        })

        $('#send').click(function () {
            hub.server.hello(v);
        });
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
});