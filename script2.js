let lineBuffer = '';
let latestValue = 3;

async function getReader() {
    port = await navigator.serial.requestPort({});
    await port.open({ baudRate: 9600 });

    connectButton.innerText = '🔌 Disconnect';
    //document.querySelector('figure').classList.remove('fadeOut');
    //document.querySelector('figure').classList.add('bounceIn');

    /*const appendStream = new WritableStream({
        write(chunk) {
            lineBuffer += chunk;

            let lines = lineBuffer.split('\n');

            if (lines.length > 1) {
                lineBuffer = lines.pop();
                latestValue = parseInt(lines.pop().trim());
                log.console(latestValue);
            }
        }
    });*/

    port.readable
        /*.pipeThrough(new TextDecoderStream())
        .pipeTo(appendStream);*/
        return port.readable.getReader();
}