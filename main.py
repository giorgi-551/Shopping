from abc import ABC, abstractmethod

class Product(ABC):
    def __init__(self, name: str, base_price: float):
        self.name = name
        self.base_price = base_price

    @abstractmethod
    def final_price(self) -> float:
        pass


class FoodProduct(Product):
    def final_price(self) -> float:
        return self.base_price * 1.05  


class ElectronicProduct(Product):
    def final_price(self) -> float:
        return self.base_price * 1.18 

class Customer:
    def __init__(self, customer_id: int, name: str, premium: bool = False):
        self.customer_id = customer_id
        self.name = name
        self.premium = premium


class ShoppingCart:
    def __init__(self, customer: Customer):
        self.customer = customer
        self.__products = [] 

    def add_product(self, product: Product):
        self.__products.append(product)

    def remove_product(self, name: str):
        for p in self.__products:
            if p.name == name:
                self.__products.remove(p)
                return True
        return False

    def copy_to(self, other_cart):
        for p in self.__products:
            other_cart.add_product(p)

    def move_to(self, other_cart):
        for p in self.__products:
            other_cart.add_product(p)
        self.__products.clear()

    def total_price(self) -> float:
        total = sum(p.final_price() for p in self.__products)

        if self.customer.premium:
            total *= 0.90  

        return total

    def get_products(self):
        return tuple(self.__products)

if __name__ == "__main__":

    apple = FoodProduct("Apple", 1.00)
    bread = FoodProduct("Bread", 2.50)
    laptop = ElectronicProduct("Laptop", 1200)
    headphones = ElectronicProduct("Headphones", 150)

    cust1 = Customer(1, "Giorgi", premium=False)
    cust2 = Customer(2, "Mariam", premium=True)   
    cust3 = Customer(3, "Nika", premium=False)

    cart1 = ShoppingCart(cust1)
    cart2 = ShoppingCart(cust2)
    cart3 = ShoppingCart(cust3)

    cart1.add_product(apple)
    cart1.add_product(bread)
    cart1.add_product(laptop)
    cart1.add_product(headphones)

    cart1.copy_to(cart2)

    cart1.move_to(cart3)

    print("Cart 1 Total:", cart1.total_price())  
    print("Cart 2 Total (premium discount applied):", cart2.total_price())
    print("Cart 3 Total:", cart3.total_price())
