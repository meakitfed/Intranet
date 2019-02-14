import React from 'react';
import { render } from 'react-dom';


class Hey extends React.Component {
	render() {
		return (
			<div> HEY REACT MARCHE YOUPI </div>
		);
	}
}

render(<Hey />, document.getElementById('app'));
