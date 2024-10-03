const galleryContainer = document.querySelector('.gallery-container')
const galleryControlsContainer = document.querySelector('.gallery-controls')
const galleryItems = document.querySelectorAll('.gallery-item')

class Carousel {
    constructor(container, items) {
        this.carouselContainer = container
        this.carouselArray = [...items]
        this.currentIndex = 0
        this.autoPlayInterval = 5000 // 5 segundos
    }

    updateGallery() {
        this.carouselArray.forEach(el => {
            el.classList.remove('gallery-item-1')
            el.classList.remove('gallery-item-2')
            el.classList.remove('gallery-item-3')
            el.classList.remove('gallery-item-4')
            el.classList.remove('gallery-item-5')
        })

        this.carouselArray.slice(0, 5).forEach((el, i) => {
            el.classList.add(`gallery-item-${i + 1}`)
        })
    }

    navigate(direction) {
        if (direction === 'previous') {
            this.carouselArray.unshift(this.carouselArray.pop())
        } else if (direction === 'next') {
            this.carouselArray.push(this.carouselArray.shift())
        }
        this.updateGallery()
    }

    setControls() {
        const prevButton = document.createElement('button')
        prevButton.className = 'gallery-prev'
        const prevImg = document.createElement('img')
        prevImg.src = '../images/icon/left-arrow.png'
        prevImg.alt = 'Previous'
        prevImg.className = 'arrow-button'
        prevButton.appendChild(prevImg)
        this.carouselContainer.appendChild(prevButton)

        const nextButton = document.createElement('button')
        nextButton.className = 'gallery-next'
        const nextImg = document.createElement('img')
        nextImg.src = '../images/icon/right-arrow.png'
        nextImg.alt = 'Next'
        nextImg.className = 'arrow-button'
        nextButton.appendChild(nextImg)
        this.carouselContainer.appendChild(nextButton)
    }

    useControls() {
        const prevButton = this.carouselContainer.querySelector('.gallery-prev')
        const nextButton = this.carouselContainer.querySelector('.gallery-next')

        prevButton.addEventListener('click', e => {
            e.preventDefault()
            this.navigate('previous')
        })

        nextButton.addEventListener('click', e => {
            e.preventDefault()
            this.navigate('next')
        })
    }

    autoPlay() {
        setInterval(() => {
            this.navigate('next')
        }, this.autoPlayInterval)
    }
}

const exempleCarousel = new Carousel(galleryContainer, galleryItems)

exempleCarousel.setControls()
exempleCarousel.useControls()
exempleCarousel.autoPlay()
