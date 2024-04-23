
let data: number | string = 42
export interface Duck {
	name: string;
	numLegs: number;
	makeSound: (sound: string) => void;
}


data = '42'
console.log(data);

const duck1: Duck = {
	name: 'huey',
	numLegs: 2,
	makeSound: (sound: string) => console.log(sound)
}
const duck2: Duck = {
	name: 'Cauey',
	numLegs: 3,
	makeSound: (sound: string) => console.log(sound)
}
export const ducks = [duck1, duck2]
console.log(duck1);