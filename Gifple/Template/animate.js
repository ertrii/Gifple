'use strict';
let Sequences;
(function(){
    const canvas = document.getElementById('canvas')
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
            plane.children[0].style.backgroundColor = '#aaa'
            plane.children[1].style.backgroundColor = '#aaa'
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

    class Sequence{
        constructor(el, images){
            this.el = document.getElementById(el)
            this.images = images
            this.btnStopAnimate = document.getElementById('btn-stop-animate')
            this.option = {
                index : 0,
                stop : false,
                repeat : true
            }            
        }
        animate(){
            if(this.option.stop) return
            let img = this.images[this.option.index]
            document.getElementById('img-canvas').src = img.src
            document.getElementById('container-img-canvas').style.transform = `translate(${img.vector.x}px, ${img.vector.y}px)`
            this.option.index++
    
            setTimeout( () => this.animate(), img.delay)
    
            if(this.option.index >= this.images.length) {
                if(this.option.repeat) this.option.index = 0
                else {
                    this.option.index = 0
                    this.option.stop = true
                    this.btnStopAnimate.innerHTML = '⊳'
                    return
                }
            }
        }
        structure(image){
            let sequenceProperty = document.createElement('div')
            sequenceProperty.setAttribute('class', 'images')
                const contentImg = document.createElement('div')
                contentImg.setAttribute('class', 'content-img')
                    const img = document.createElement('img')
                    img.setAttribute('src', image.src)
                contentImg.appendChild(img)
                
                const contentProperty = document.createElement('div')
                contentProperty.setAttribute('class', 'content-property')
                    const p1 = document.createElement('p')
                        const strong1 = document.createElement('strong')
                        strong1.appendChild(document.createTextNode(`#${image.index}`))
                    p1.appendChild(strong1)

                    const p2 = document.createElement('p')
                        const strong2 = document.createElement('strong')
                        strong2.appendChild(document.createTextNode('Delay: '))
                    p2.appendChild(strong2)
                    p2.appendChild(document.createTextNode(image.delay))

                    const p3 = document.createElement('p')
                        const strong3 = document.createElement('strong')
                        strong3.appendChild(document.createTextNode('x: '))
                    p3.appendChild(strong3)
                    p3.appendChild(document.createTextNode(image.vector.x))

                    const p4 = document.createElement('p')
                        const strong4 = document.createElement('strong')
                        strong4.appendChild(document.createTextNode('y: '))
                    p4.appendChild(strong4)
                    p4.appendChild(document.createTextNode(image.vector.y))
                contentProperty.appendChild(p1)
                contentProperty.appendChild(p2)
                contentProperty.appendChild(p3)
                contentProperty.appendChild(p4)
            sequenceProperty.appendChild(contentImg)
            sequenceProperty.appendChild(contentProperty)
            return sequenceProperty

        }
        start(){
            this.animate()
            this.btnStopAnimate.onclick = () =>{
                if(!this.option.stop){
                    this.option.stop = true
                    this.btnStopAnimate.innerHTML = '⊳'
                }
                else {
                    this.option.stop = false
                    this.btnStopAnimate.innerHTML = '∎'
                    this.animate()
                }
            }
            const containerSequence = document.createElement('div')
            this.images.forEach(image => {
                containerSequence.appendChild(this.structure(image))
            });
            this.el.appendChild(containerSequence)
        }
    }


    Sequences = Sequence
})()

fetch('images.json').
    then( response =>{
        return response.json()
    })
    .then( images => {

        fetch('config.json').then( response => {
            return response.json()
        }).then( config => {
            document.getElementById('head-title').innerHTML = config.proyectName
            document.getElementById('proyect-name').innerHTML = config.proyectName
            document.getElementById('autor').innerHTML = config.autor
            document.getElementById('description').innerHTML = config.description
            const sequence = new Sequences('sequence', images)
            sequence.option.repeat = config.repeat
            sequence.start()
        }).catch( () => console.error('Error config.json'))

    })
    .catch( () => console.error('Error images.json'))