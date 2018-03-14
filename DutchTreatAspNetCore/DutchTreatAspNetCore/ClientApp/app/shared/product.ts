//как формируем: из api берем ответ через postman, потом формируем список полей через http://json2ts.com/
export interface Product {
    id: number;
    category: string;
    size: string;
    price: number;
    title: string;
    artDescription: string;
    artDating: string;
    artId: string;
    artist: string;
    artistBirthDate: Date;
    artistDeathDate: Date;
    artistNationality: string;
}