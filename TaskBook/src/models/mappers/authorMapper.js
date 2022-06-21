import Author from '../author'

export default class AuthorMapper{

    static mapAuthor(data){
        return new Author(data.id, data.name)
    }

    static mapAuthors(data){
        return data.map(author=> {return this.mapAuthor(author)})
    }
}