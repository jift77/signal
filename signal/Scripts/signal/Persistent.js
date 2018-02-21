$(function () {
    var c = $.connection('echo');
    c.received((msg) => {
        console.log('Received:' + msg.body)
    }).start().done(() => {
        c.send({ body : 'hello'});
        });
})