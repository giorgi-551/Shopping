abstract class Product {
    constructor(
        public name: string,
        public basePrice: number
    ) {}

    abstract finalPrice(): number;
}

class FoodProduct extends Product {
    finalPrice(): number {
        return this.basePrice * 1.05;
    }
}

class ElectronicProduct extends Product {
    finalPrice(): number {
        return this.basePrice * 1.18;
    }
}

class Customer {
    constructor(
        public id: number,
        public name: string,
        public premium: boolean
    ) {}
}

class ShoppingCart {
    private products: Product[] = [];

    constructor(public customer: Customer) {}

    addProduct(product: Product): void {
        this.products.push(product);
    }

    removeProduct(name: string): boolean {
        const index = this.products.findIndex(p => p.name === name);
        if (index !== -1) {
            this.products.splice(index, 1);
            return true;
        }
        return false;
    }

    copyTo(other: ShoppingCart): void {
        for (const p of this.products) {
            other.addProduct(p);
        }
    }

    moveTo(other: ShoppingCart): void {
        for (const p of this.products) {
            other.addProduct(p);
        }
        this.products = [];
    }

    totalPrice(): number {
        let total = this.products.reduce((sum, p) => sum + p.finalPrice(), 0);

        if (this.customer.premium) {
            total *= 0.90; 
        }
        return total;
    }

    getProducts(): ReadonlyArray<Product> {
        return this.products;
    }
}


function main() {
    const apple = new FoodProduct("Apple", 1.00);
    const bread = new FoodProduct("Bread", 2.50);
    const laptop = new ElectronicProduct("Laptop", 1200);
    const headphones = new ElectronicProduct("Headphones", 150);

    const cust1 = new Customer(1, "Giorgi", false);
    const cust2 = new Customer(2, "Mariam", true);
    const cust3 = new Customer(3, "Nika", false);

    const cart1 = new ShoppingCart(cust1);
    const cart2 = new ShoppingCart(cust2);
    const cart3 = new ShoppingCart(cust3);

    cart1.addProduct(apple);
    cart1.addProduct(bread);
    cart1.addProduct(laptop);
    cart1.addProduct(headphones);

    cart1.copyTo(cart2);

    cart1.moveTo(cart3);

    console.log("Cart 1 Total:", cart1.totalPrice());
    console.log("Cart 2 Total (premium):", cart2.totalPrice());
    console.log("Cart 3 Total:", cart3.totalPrice());
}

main();
