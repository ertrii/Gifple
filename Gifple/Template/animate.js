'use strict';
(function(){
    const canvas = document.getElementById('gif-container')
    const plane = document.getElementById('plane')
    let themeCanvas = 0

    canvas.onclick = () =>{
        if(themeCanvas === 1){
            //theme dark
            canvas.style.backgroundColor = '#424242'
            plane.children[0].style.backgroundColor = '#555'
            plane.children[1].style.backgroundColor = '#555'
            themeCanvas = 0
        }else{
            //theme white
            canvas.style.backgroundColor = '#ccc'
            plane.children[0].style.backgroundColor = '#eee'
            plane.children[1].style.backgroundColor = '#eee'
            themeCanvas = 1
        }
    }

    const btnPlane = document.getElementById('btn-plane')
    let planeVisible = true
    btnPlane.onclick = function(){
        if(planeVisible){
            plane.style.visibility = 'hidden'
            planeVisible = false
        }
        else{
            plane.style.visibility = 'visible'
            planeVisible = true
        }
    }

    const containerImg = document.getElementById('container-img-canvas')
    const imgCanvas = document.getElementById('img-canvas')
    const sequencesImg = [
        {
            index : 0,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/0',
            delay : 100,
            vector : {
                x : 6,
                y : -33
            }
        },
        {
            index : 1,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/1',
            delay : 60,
            vector : {
                x : 0,
                y : -32
            }
        },
        {
            index : 2,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/2',
            delay : 60,
            vector : {
                x : -6,
                y : -33
            }
        },
        {
            index : 3,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/3',
            delay : 60,
            vector : {
                x : -12,
                y : -32
            }
        },
        {
            index : 4,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/4',
            delay : 60,
            vector : {
                x : -18,
                y : -33
            }
        },
        {
            index : 5,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/5',
            delay : 60,
            vector : {
                x : -24,
                y : -32
            }
        },
        {
            index : 6,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/6',
            delay : 60,
            vector : {
                x : -30,
                y : -33
            }
        },
        {
            index : 7,
            src : 'https://maplestory.io/api/0/83/npc/10000/render/move/7',
            delay : 60,
            vector : {
                x : -36,
                y : -32
            }
        }
    ]
    let index = 0, stopAnimate = false, repeat = true
    const btnStopAnimate = document.getElementById('btn-stop-animate')
    const animate = () => {
        if(stopAnimate) return
        let img = sequencesImg[index]
        imgCanvas.src = img.src
        containerImg.style.transform = `translate(${img.vector.x}px, ${img.vector.y}px)`
        index++
        
        if(index >= sequencesImg.length) {
            if(repeat) index = 0
            else {
                index = 0
                stopAnimate = true
                btnStopAnimate.innerHTML = '⊳'
                return
            }
        }
        setTimeout(()=>{
            animate()
        }, sequencesImg[index].delay)
    }
    animate()
    btnStopAnimate.onclick = () =>{
        if(!stopAnimate){
            stopAnimate = true
            btnStopAnimate.innerHTML = '⊳'
        }
        else {
            stopAnimate = false
            btnStopAnimate.innerHTML = '∎'
            animate()
        }
    }
    repeat = false
})()