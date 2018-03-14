export class StoreCustomer {
    private ourName: string;
    public visits: number;

    constructor(private firstName: string, private lastName: string) {

    }


    public showName() {
        alert(this.firstName + " " + this.lastName);
    }

    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName;
    }
}
