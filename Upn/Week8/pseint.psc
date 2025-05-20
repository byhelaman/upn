Algoritmo sin_titulo
	Definir categoria Como Caracter
	Definir horas_trabajo, sueldo_bruto, sueldo_neto, descuento, tarifa  Como Real
	
	Escribir "Ingrese su categoría: [A - D]"
	Repetir
		Leer categoria
		categoria = Minusculas(categoria)
	Hasta Que categoria = "a" O categoria = "b" O categoria = "c" O categoria = "d"
	
	Escribir "Ingrese las horas trabajadas: "
	
	Repetir
		Leer horas_trabajo
	Hasta Que horas_trabajo > 0
	
	Segun categoria Hacer
		"a":
			tarifa = 21.0
			sueldo_bruto = horas_trabajo * tarifa
		"b":
			tarifa = 19.5
			sueldo_bruto = horas_trabajo * tarifa
		"c":
			tarifa = 17.0
			sueldo_bruto = horas_trabajo * tarifa
		"d":
			tarifa = 15.5
			sueldo_bruto = horas_trabajo * tarifa
		De Otro Modo:
			Escribir "Categoria invalida"
	Fin Segun
	
	descuento = 0.15
	
	Si sueldo_bruto > 2500 Entonces
		descuento = 0.20
	FinSi
	
	sueldo_neto = sueldo_bruto - sueldo_bruto * descuento
	
	Escribir ""
	Escribir "Horas de Trabajo: ", horas_trabajo
	Escribir "Tarifa: ", tarifa
	Escribir "Sueldo Bruto: ", sueldo_bruto
	Escribir "Descuento: ", descuento * 100, "%"
	Escribir "Sueldo Neto: ", sueldo_neto
	
FinAlgoritmo
