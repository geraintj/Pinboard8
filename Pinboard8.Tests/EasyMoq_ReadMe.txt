EasyMoq
#######

EasyMoq, currently the main part of the framework, is a mocking-framework I developed since there are no usable mocking-framework for windows phone development.
Good existing framework cannot be used in wp-projects since they generate proxy-objects on the fly.
My idea was to just generate the mocks with features that are supported in VS and do not require any extensions. So I came across the usage of T4-templating.
Now you just have to configure your mocks and run the T4-template generator.
This process will create your mocks - and the framework behind them will handle your calls to the mocked type.

Example:

1.
Create your interface you wanna mock.
______________________________
I                            I
I  public interface IObject  I
I  {                         I
I      bool Do();            I
I  }                         I
I____________________________I


2.
Create a new class, that has the [EasyMoqGenerator]-attribute and derives from EasyMoqGenerator. This forces you to implement the Configure-method.
___________________________________________________________________
I                                                                 I
I  [EasyMoqGenerator]                                             I
I  public void EasyMoqGeneratorImpl : EasyMoqGenerator            I
I  {                                                              I
I      protected override void Configure(IEasyMoqConfig config)   I
I      {                                                          I
I           config.TargetNamespace = "MyProject.MyNamespace";     I
I                                                                 I
I           config.CreateMockFor<IObject>();                      I
I      }                                                          I
I  }                                                              I
I_________________________________________________________________I


3.
Rebuild your solution. Since EasyMoq uses reflection and therefore metadata of your types, the projects need to be (re-)built first.


4.
Run the Custom Tool on the EasyMoq.tt-Template (called from the context menu of the *.tt-file). This will generate the mocks and the hook for the framework to use your mocks.


5.
Use the framework as shown below - and happy mocking ;-)
__________________________________________________
I                                                I
I  // Calling the factory                        I
I  var mock = Easy.Moq.Mock<IObject>();          I
I  // Setting up behavior                        I
I  mock.Setup(m => m.Do()).Returns(true);        I
I                                                I
I  // Calling the method on the mock             I
I  var result = mock.Object.Do();                I
I                                                I  
I  // Verify the call(s)                         I
I  mock.Verify(m => m.Do(), Conditions.Once());  I
I________________________________________________I


Notice: "mock" is not exactly the generated mock. It's an instance of a helper for your mocked type.
The actual mocked type is behind the mock.Object-property and has only the methods the original type provided.

In other projects I used Moq for mocking my types. Since this is the only mocking-framework I know my framework looks quite the same as Moq - but everything has been rewritten from scratch and in my own coding style.
But that does not have to bother you since you won't see much of that code. But if you are familiar with Moq, you'll get started quite easy.

UPDATE 01.05.2013
#################

Event-mocking is now supported. Just run the EasyMoq.Extensions.tt and add "using EasyMoq.Extensions" to your testfiles. The Extensions.tt generates event-wrapper-methods that can be used as action-parameter in the Raise()-setup.
I'll update the CodePlex documentation as soon as I find some time.


For further reading, please visit the project's CodePlex site --> http://wp7fx.codeplex.com/wikipage?title=WP-Fx.EasyMoq
If you'll have some trouble with the framework, don't bother to get in contact with me.



Kind regards,
Lukas Kretschmar, 2013
