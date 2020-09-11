using BenchmarkDotNet.Attributes;
using Humanizer;

namespace HumanizerBenchmarks
{
    [MemoryDiagnoser]
    public class SpanBenchmarks
    {
        private const string MyText = @"
Lorem IPSUM DOLOR SIT AMET, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna
aliqua. Turpis egestas sed tempus urna. Vel pharetra vel turpis nunc eget lorem dolor. A diam sollicitudin tempor id
eu nisl. Nunc scelerisque viverra mauris in aliquam. Massa eget egestas purus viverra accumsan in. Fermentum et
sollicitud in ac orci phasellus -_egestas. - Purus ut faucibus pulvinar elementum integer enim neque volutpat ac. Adipiscing
tristique risus nec feugiat in fermentum. Ut_faucibus_pulvinar elementum integer enim neque volutpat. Ipsum dolor sit
amet consectetur adipiscing elit ut aliquam. Donec et odio pellentesque diam volutpat commodo sed egestas. Congue nisi
vitae suscipit tellus mauris. Mi in nulla posuere sollicitudin aliquam ultrices sagittis orci a. Quam nulla porttitor
massa id neque aliquam vestibulum. Nisl suscipit adipiscing bibendum est ultricies integer. Imperdiet sed euismod nisi
porta lorem.

Viverra nibh cras pulvinar mattis. Lorem mollis aliquam ut porttitor. Tellus in hac habitasse platea dictumst vestibulum
rhoncus est pellentesque. Sed cras ornare arcu dui vivamus arcu-Felis. Blandit Volutpat MAECENAS voLutpat blandit
aliquam etiam erat velit. Eu augue ut lectus arcu bibendum at varius vel pharetra. Senectus et netus et malesuada fames
ac turpis. At volutpat diam ut venenatis. Adipiscing at in tellus integer feugiat scelerisque. Diam- quis enim lobortis
scelerisque fermentum dui faucibus in. Nibh tellus molestie nunc non. Phasellus faucibus scelerisque -eleifend donec.
Porta nibh venenatis cras sed. Consequat id porta nibh venenatis. Leo vel fringilla est ullamcorper eget.

Cursus mattis molestie a iaculis at erat pellentesque adipiscing. Non enim praesent elementum facilisis leo vel
fringilla est ullamcorper. Augue interdum velit euismod in pellentesque massa placerat. Habitasse platea dictumst
quisque sagittis purus sit amet volutpat consequat. Volutpat est velit egestas dui id. Neque laoreet suspendisse
interdum consectetur. Nunc aliquet bibendum enim facilisis. Curabitur gravida arcu ac tortor dignissim convallis aenean
et tortor. Sagittis nisl rhoncus mattis rhoncus urna neque viverra justo. Amet nisl purus in mollis nunc_sed id_ semper.
Enim blandit volutpat maecenas volutpat blandit aliquam. Mauris pharetra et ultrices neque ornare aenean. Et _leo duis ut
diam quam. In nisl nisi scelerisque eu ultrices. Felis eget nunc lobortis mattis aliquam. Faucibus a pellentesque sit
amet porttitor eget dolor morbi. Sollicitudin ac orci phasellus egestas tellus rutrum tellus pellentesque eu. Odio ut
enim blandit volutpat maecenas volutpat blandit. Diam sollicitudin tempor id eu nisl nunc mi.

Praesent tristique magna sit amet purus. Cursus mattis molestie a iaculis. Lectus arcu bibendum at varius vel pharetra
vel turpis. Ultrices neque ornare aenean euismod elementum nisi quis. Morbi tristique senectus et netus et malesuada
fames. Magna eget est lorem ipsum dolor sit amet consectetur adipiscing. Hac habitasse platea dictumst quisque sagittis.
Nunc id cursus metus aliquam eleifend mi in nulla posuere. Ultrices dui sapien eget mi proin sed libero enim. Id neque
aliquam vestibulum morbi. Nunc id cursus metus aliquam eleifend mi. Dui ut ornare lectus sit. Suscipit tellus mauris a
diam maecenas sed enim ut.

Nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc. Quisque non tellus orci ac. Risus commodo
viverra maecenas accumsan lacus. Diam ut venenatis tellus in metus vulputate eu scelerisque. Elementum eu facilisis sed
odio. Vitae sapien pellentesque habitant morbi tristique senectus et netus et. Arcu felis bibendum ut tristique et
egestas quis. In ornare quam viverra orci sagittis eu volutpat odio facilisis. Nec tincidunt praesent semper feugiat
nibh sed pulvinar proin. Condimentum id venenatis a condimentum vitae sapien pellentesque habitant. Ac turpis egestas
maecenas pharetra convallis posuere morbi leo urna. Proin sagittis nisl rhoncus mattis rhoncus urna neque. Nisi lacus
sed viverra tellus. Euismod quis viverra nibh cras pulvinar mattis nunc sed blandit. Scelerisque viverra mauris in
aliquam sem. Habitant morbi tristique senectus et netus et malesuada. Consectetur adipiscing elit duis tristique
sollicitudin nibh sit amet commodo.";

        [Benchmark(Baseline = true)]
        public void Humanize()
        {
            MyText.Humanize();
        }
    }
}
