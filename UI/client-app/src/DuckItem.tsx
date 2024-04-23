import { Duck } from "./demo";

interface Iprop {
	duck: Duck;
}

export default function DuckItem({ duck }: Iprop) {
	return (
		<div key={duck.name}>
			<span>{duck.name}</span>
			<button onClick={() => duck.makeSound(duck.name + ' quack')}>ClickMe</button>
		</div>
	)
}

