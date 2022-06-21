export default class Book {
    constructor(id,name, author, year, genre, authorId, genreId){
        this.id = id
        this.name = name
        this.author = author
        this.year = year
        this.genre = genre
        this.authorId = authorId
        this.genreId = genreId
        this.selected = false
    }
}