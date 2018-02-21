$(function () {
    var hubEx = $.connection.Exclude, connectionId;
    hubEx.client.connections = function (ids) {
        $('#ids').empty()
        for (var i = 0, l = ids.length; i < l; i++) {
            let id = ids[i]
            if (id !== connectionId) {
                $('#ids').append($('<option/>').attr('value', id).html(id))
            }
        }
        if (ids.length) $('#sender').show()
    }

    hubEx.client.greetings = function (msg) {
        $('#messagesEx').append($('<li/>').html(msg))
    }

    $.connection.hub.start().done(function () {
        connectionId = $.connection.hub.id
        $('#id').html(connectionId)

        hubEx.server.subscribe();
        $('#sendEx').click(function () {
            hubEx.server.helloBut($('#ids').val())
        })
    })
})