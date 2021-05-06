const connectButton = document.getElementById('connect-button');
let port;

if ('serial' in navigator) {
    connectButton.addEventListener('click', async function () {
        //console.log(unityInstance);
        const reader = await getReader();
        let string = "";
        const decoder = new TextDecoder("utf-8");
        try {
            while (true) {
                const { value, done } = await reader.read();
                const decodedValue = decoder.decode(value);
                console.log(value);
                if (done) {
                    break;
                }
                if (decodedValue.includes("a")) {
                    string += decodedValue.replace("a", "");
                    console.log(decodedValue);
                }
                else {
                    unityInstance.SendMessage('Car1', 'SetValue', string);
                    console.log(string);
                    string = "";
                }
            }
        } catch (error) {
        } finally {
            reader.releaseLock();
        }
    });
    connectButton.disabled = false;
}
else {
    const firstBubble = document.querySelector('p.bubble');
    const noSerialSupportNotice = document.createElement('p');
    noSerialSupportNotice.innerHTML = '<p class="notice bubble">You\'re on the right track! This browser is lacking support for Web Serial API, though, and thats a bummer.</p>';

    firstBubble.parentNode.insertBefore(noSerialSupportNotice, firstBubble.nextSibling);
}
