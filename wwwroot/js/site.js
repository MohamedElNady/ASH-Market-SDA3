// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
routeUrl = location.protocol + '//' + location.host;
var cookie = [];
var numberOfCookies;
var totalprice = 0;
var pricelist = [];
function fnSaveData() {
	var brand = document.getElementById('productName').innerText;
	var name = document.getElementById('productBrand').innerText;
	var price = document.getElementById('productPrice').innerText;
	var img = document.getElementById('productImg').src;
	var productId = document.getElementById('productId').innerText;

	let openRequest = indexedDB.open("store", 1);


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

		let product = {
			price: price,
			img: img,
			name: name,
			brand: brand,
			"id": productId
		};


		let request = products.add(product);
		request.onsuccess = function () { // (4)
			sweetAlert("Successfully Add", "Item Add Added To Cart", "success");

		};
		let count = products.count();

		count.onsuccess = function () {
			console.log(count.result);
			document.getElementById('itemsCart').innerText = (parseInt(count.result)).toString();
		};

		request.onerror = function () {
			sweetAlert("Already Add", "Item Already Added To Cart", "info");
		};
	};




}

$(document).ready(function () {

	let openRequest = indexedDB.open("store", 1);


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


		let count = products.count();

		count.onsuccess = function () {

			document.getElementById('itemsCart').innerText = (parseInt(count.result)).toString();
			/*    document.getElementById('bla').value = (parseInt(count.result)).toString();*/
		};


		let items = products.getAll();
		items.onsuccess = function () {
			items.result.forEach(myFunction)

			function myFunction(item) {
				var requestData = {

					price: item.price,
					id: item.id,
					img: item.img,
					name: item.brand,
					brand: item.name
				};

				cookie.push(requestData);

			}
		}
	};


	document.getElementById("clickcart").addEventListener("click", onGoToCart);
	function onGoToCart() {

		window.location.replace(routeUrl + '/Buying/Cart');
		$.ajax({
			url: routeUrl + '/Buying/getData',
			type: 'POST',
			data: JSON.stringify(cookie),
			contentType: "application/json",
			dataType: "json",
			success: function (response) {

				if (response.status === 1) {

					/*window.location.replace(routeUrl + '/Buying/Cart');*/
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


});
