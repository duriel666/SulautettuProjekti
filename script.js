// <button id="connect-button" type="button" disabled>🔌 Connect</button>
// <script src="script.js"> // muista index.html
const connectButton = document.getElementById('connect-button');
let port;

if ('serial' in navigator) {
    connectButton.addEventListener('click', async function () {
        console.log(unityInstance);
        /*if (port) {
            port.close();
            port = undefined;

            connectButton.innerText = '🔌 Connect';
            document.querySelector('figure').classList.replace('bounceIn', 'fadeOut');
        }*/
        //else {
            const reader=await getReader();
            //console.log(reader);
            try {
                while (true) {
                  const { value, done } = await reader.read();
                  if (done) {
                    // |reader| has been canceled.
                    break;
                  }
                  // Do something with |value|...
                  unityInstance.SendMessage('Car1','SetValue', value.join(","));
                  setTimeout(()=>{console.log(value)},500);
                }
              } catch (error) {
                // Handle |error|...
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