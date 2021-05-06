let lineBuffer = '';
let latestValue = 3;

async function getReader() {
    port = await navigator.serial.requestPort({});
    await port.open({ baudRate: 9600 });
    connectButton.innerText = '🔌 Disconnect';
    port.readable
    return port.readable.getReader();
}
