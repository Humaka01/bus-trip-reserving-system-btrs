const audio = document.getElementById("background-audio");
audio.volume = 0.4;

function playAudioWithRandomStart() {
    const maxDuration = audio.duration;
    const randomStartTime = Math.random() * maxDuration;
    audio.currentTime = randomStartTime;
    audio.play();
}

window.addEventListener("load", playAudioWithRandomStart);