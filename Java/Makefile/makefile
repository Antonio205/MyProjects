# makefile z_4

.SUFFIXES: .class .java

PACK=z_4
TARG=Main
JC=javac -g
JM=java -ea -jar
JR=jar -cfe

OBJ=$(PACK)/NonLinearEquation.class \
    $(PACK)/Main.class

.java.class:
	$(JC) $<

run: build
	$(JM) $(TARG).jar

build: 	$(OBJ)
	$(JR) $(TARG).jar $(PACK).Main $(OBJ)

clean:
	for %%f in ($(OBJ)) do del %%f
	del $(TARG).jar

$(PACK)/NonLinearEquation.class: $(PACK)/NonLinearEquation.java makefile

$(PACK)/Main.class: $(PACK)/Main.java makefile

# eof makefile z_4