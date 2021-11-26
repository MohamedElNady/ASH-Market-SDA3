routeUrl = location.protocol + '//' + location.host;


var totalprice = 0;
let openRequest = indexedDB.open("store", 1);
var cookie = [];
window.onload = myFunction;


function myFunction() {

	$.ajax({
		url: routeUrl + '/Buying/getData',
		type: 'POST',
		data: JSON.stringify(cookie),
		contentType: "application/json",
		dataType: "json",
		success: function (response) {

			if (response.status === 1) {
	
			}
			if (response.status === 0) {

				alert('error');

			}


		},
		error: function (xhr) {
			$.notify("Error", "error");
		}

	});
}

openRequest.onupgradeneeded = function () {
	let db = openRequest.result;
	if (!db.objectStoreNames.contains('products')) { // if there's no "books" store
		db.createObjectStore('products', { keyPath: "id" }); // create it
	}
};

openRequest.onerror = function () {
	console.error("Error", openRequest.error);
};

openRequest.onsuccess = function () {
	let db = openRequest.result;

	let transaction = db.transaction("products", "readwrite");
	let products = transaction.objectStore("products");

	function deletewithid(id) {

		products.delete(id);
	}

	let items = products.getAll();
	items.onsuccess = function () {
		items.result.forEach(myFunction)

		function myFunction(item) {
			var removedollar = item.price.substring(1);
			totalprice = totalprice + parseInt(removedollar);
			console.log(totalprice);

			var requestData = {
				price: item.price,
				id: item.id,
				img: item.img,
				name: item.brand,
				brand: item.name
			};
			cookie.push(requestData);

		}
		var total = totalprice;
		document.getElementById('priceTotal').innerText = '$' + total;
	};

}
function removeitem(id) {
	let db = openRequest.result;

	let transaction = db.transaction("products", "readwrite");
	let products = transaction.objectStore("products");
	products.delete(id);
	document.location.reload();
}







